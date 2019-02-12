using AutoMapper;
using LocusNew.Core.AdminViewModels;
using LocusNew.Helpers;
using System.IO;
using System.Web;
using System.Web.Mvc;
using LocusNew.Core;
using LocusNew.Persistence;

namespace LocusNew.Areas.Admin.Controllers
{
    [Authorize]
    public class GlobalSettingsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GlobalSettingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var model = Mapper.Map<GlobalSettingsViewModel>(_unitOfWork.GlobalSettings.GetGlobalSettings());

            model.CityParts = _unitOfWork.CityParts.GetCityParts();

            return View(model);
        }

        [HttpPost]
        public string UploadImage(HttpPostedFileBase file)
        {
            var path = "~/DynamicContent/CityPartsHomepage";
            var imgPath = "";

            if (file != null)
            {
                imgPath = Path.Combine(Server.MapPath(path), file.FileName);
                file.SaveAs(imgPath);
            }

            return @"/DynamicContent/CityPartsHomepage/" + file.FileName;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveSettings(GlobalSettingsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = "/DynamicContent/CityPartsHomepage";
                var GlobalSettingDb = _unitOfWork.GlobalSettings.GetGlobalSettings();
                
                Mapper.Map(model, GlobalSettingDb);

                if (model.File1 != null)
                {
                    GlobalSettingDb.Image1path = Path.Combine(Server.MapPath(path), model.File1.FileName);
                    model.File1.SaveAs(GlobalSettingDb.Image1path);
                    GlobalSettingDb.CityPart1Image = model.File1.FileName;
                }
                if (model.File2 != null)
                {
                    GlobalSettingDb.Image2path = Path.Combine(Server.MapPath(path), model.File2.FileName);
                    model.File2.SaveAs(GlobalSettingDb.Image2path);
                    GlobalSettingDb.CityPart2Image = model.File2.FileName;
                }
                if (model.File3 != null)
                {
                    GlobalSettingDb.Image3path = Path.Combine(Server.MapPath(path), model.File3.FileName);
                    model.File3.SaveAs(GlobalSettingDb.Image3path);
                    GlobalSettingDb.CityPart3Image = model.File3.FileName;
                }
                if (model.File4 != null)
                {
                    GlobalSettingDb.Image4path = Path.Combine(Server.MapPath(path), model.File4.FileName);
                    model.File4.SaveAs(GlobalSettingDb.Image4path);
                    GlobalSettingDb.CityPart4Image = model.File4.FileName;
                }
                if (model.File5 != null)
                {
                    GlobalSettingDb.Image5path = Path.Combine(Server.MapPath(path), model.File5.FileName);
                    model.File5.SaveAs(GlobalSettingDb.Image5path);
                    GlobalSettingDb.CityPart5Image = model.File5.FileName;
                }
                if (model.File6 != null)
                {
                    GlobalSettingDb.Image6path = Path.Combine(Server.MapPath(path), model.File6.FileName);
                    model.File6.SaveAs(GlobalSettingDb.Image6path);
                    GlobalSettingDb.CityPart6Image = model.File6.FileName;
                }

                _unitOfWork.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}