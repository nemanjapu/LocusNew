using LocusNew.Controllers;
using LocusNew.Persistence;
using LocusNew.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.WebApi;
using LocusNew.Core;
using LocusNew.Core.Repositories;
using LocusNew.Persistence.Repositories;
using Unity.Lifetime;
using Microsoft.Owin.Security;
using System.Web;

namespace LocusNew
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IAuthenticationManager>( new InjectionFactory(o => System.Web.HttpContext.Current.GetOwinContext().Authentication));

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<ICityPartsRepository, CityPartsRepository>();
            container.RegisterType<IGlobalSettingsRepository, GlobalSettingsRepository>();
            container.RegisterType<ILeadsRepository, LeadsRepository>();
            container.RegisterType<IListingImagesRepository, ListingImagesRepository>();
            container.RegisterType<IListingsRepository, ListingsRepository>();
            container.RegisterType<IPropertyBuyersRepository, PropertyBuyersRepository>();
            container.RegisterType<IPropertyOwnersRepository, PropertyOwnersRepository>();
            container.RegisterType<IPropertyTypesRepository, PropertyTypesRepository>();
            container.RegisterType<ISellerLeadsRepository, SellerLeadsRepository>();
            container.RegisterType<IShowingsRepository, ShowingsRepository>();
            container.RegisterType<IUsersRepository, UsersRepository>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}