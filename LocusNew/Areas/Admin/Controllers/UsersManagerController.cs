using AutoMapper;
using LocusNew.Core.AdminViewModels;
using LocusNew.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LocusNew.Core;

namespace LocusNew.Areas.Admin.Controllers
{
    [Authorize]
    public class UsersManagerController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public UsersManagerController(IUnitOfWork unitOfWork, ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            _unitOfWork = unitOfWork;
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            var model = _unitOfWork.Users.GetUsersByActivity(true).AsEnumerable()
                .Select(u => new ViewUsersViewModel()
                {
                    Id = u.Id,
                    Name = u.FirstName + " " + u.LastName,
                    Role = u.Designation,
                    NumberOfListings = _unitOfWork.Listings.GetListingsNumberForAgent(u.Id)
                }).AsEnumerable();

            return View(model);
        }

        public ActionResult InactiveUsers()
        {
            var model = _unitOfWork.Users.GetUsersByActivity(false).AsEnumerable()
                .Select(u => new ViewUsersViewModel()
                {
                    Id = u.Id,
                    Name = u.FullName,
                    Role = u.Designation,
                    NumberOfListings = _unitOfWork.Listings.GetListingsNumberForAgent(u.Id)
                }).ToList();

            return View(model);
        }

        public ActionResult ToggleActiveUser(string id)
        {
            var user = _unitOfWork.Users.GetApplicationUser(id);
            user.isActive = !user.isActive;

            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        public ActionResult EditUser(string id)
        {
            TempData["ErrorMessage"] = TempData["ErrorMessage"] as string;
            var model = Mapper.Map<AddUserViewModel>(_unitOfWork.Users.GetApplicationUser(id));

            return View("EditUser", model);
        }

        public ActionResult AddUser()
        {
            var model = new AddUserViewModel();

            return View("AddUser", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveNewUser(AddUserViewModel model)
        {
            var UserImgPath = "/DynamicContent/UserImages";
            var UserCardPath = "/DynamicContent/UserImages/Cards";

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                isAgent = model.isAgent,
                isAdmin = model.isAdmin,
                ImageName = model.File.FileName,
                ImagePath = Path.Combine(Server.MapPath(UserImgPath), model.File.FileName),
                AgentCardImageName = model.AgentCardFile.FileName,
                AgentCardImagePath = Path.Combine(Server.MapPath(UserCardPath), model.AgentCardFile.FileName),
                isActive = model.isActive,
                isDev = false,
                PhoneNumber = model.PhoneNumber,
                Designation = model.Designation
            };
            var result = await UserManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("AddUser");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEditedUser(AddUserViewModel user)
        {
            var userDB = _unitOfWork.Users.GetApplicationUser(user.Id);
            var UserImgPath = "/DynamicContent/UserImages";
            var UserCardPath = "/DynamicContent/UserImages/Cards";
            userDB.isActive = user.isActive;
            if (user.File != null)
            {
                userDB.ImageName = user.File.FileName;
                userDB.ImagePath = Path.Combine(Server.MapPath(UserImgPath), user.File.FileName);
                user.File.SaveAs(userDB.ImagePath);
            }
            if (user.AgentCardFile != null)
            {
                userDB.AgentCardImageName = user.AgentCardFile.FileName;
                userDB.AgentCardImagePath = Path.Combine(Server.MapPath(UserCardPath), user.AgentCardFile.FileName);
                user.AgentCardFile.SaveAs(userDB.AgentCardImagePath);
            }
            userDB.isAdmin = user.isAdmin;
            userDB.isAgent = user.isAgent;
            userDB.LastName = user.LastName;
            userDB.FirstName = user.FirstName;
            userDB.PhoneNumber = user.PhoneNumber;
            userDB.Email = user.Email;
            userDB.Designation = user.Designation;

            _unitOfWork.Complete();

            //Clear cache on "About us" page and on all listing pages after an agent has been updated.
            var urlToRemove = Url.Action("Index", "AboutUs", new { area = "" });
            Response.RemoveOutputCacheItem(urlToRemove);

            IQueryable<Listing> listingsToClearCache = _unitOfWork.Listings.GetListings();
            foreach (var item in listingsToClearCache)
            {
                Response.RemoveOutputCacheItem(Url.Action("Listing", "Search", new { id = item.Id, area = "" }));
            }

            return RedirectToAction("Index");
        }

        public ActionResult ChangePassword(string id)
        {
            var model = new ChangePasswordViewModel()
            {
                UserId = id
            };

            return PartialView("ChangePassword", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.CurrentPassword, model.Password);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            TempData["ErrorMessage"] = "Neispravna trenutna lozinka!";
            return RedirectToAction("EditUser", new { id = model.UserId });
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        #endregion

    }
}