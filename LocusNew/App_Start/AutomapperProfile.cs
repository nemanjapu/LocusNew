using AutoMapper;
using LocusNew.Core.AdminViewModels;
using LocusNew.Core.Models;
using LocusNew.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LocusNew.App_Start
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<SellerLeadViewModel, SellerLead>().ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<LeadViewModel, Lead>().ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.Now));

            //LISTING LIST ON HOMEPAGE AND ON SEARCH
            CreateMap<Listing, ListingsListViewModel>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Images.OrderBy(img => img.SortOrder).ThenBy(img => img.Id).FirstOrDefault()));
            //LISTING LIST ON HOMEPAGE AND ON SEARCH

            //GLOBAL SETTINGS HOME CONTROLLER
            CreateMap<GlobalSettings, HomeGlobalSettingsViewModel>()
                .ForMember(dest => dest.CityPart1NumberOfListings, opt => opt.MapFrom(src => Helpers.LayoutGetValues.GetListingsNumberForCities(src.CityPart1Id)))
                .ForMember(dest => dest.CityPart2NumberOfListings, opt => opt.MapFrom(src => Helpers.LayoutGetValues.GetListingsNumberForCities(src.CityPart2Id)))
                .ForMember(dest => dest.CityPart3NumberOfListings, opt => opt.MapFrom(src => Helpers.LayoutGetValues.GetListingsNumberForCities(src.CityPart3Id)))
                .ForMember(dest => dest.CityPart4NumberOfListings, opt => opt.MapFrom(src => Helpers.LayoutGetValues.GetListingsNumberForCities(src.CityPart4Id)))
                .ForMember(dest => dest.CityPart5NumberOfListings, opt => opt.MapFrom(src => Helpers.LayoutGetValues.GetListingsNumberForCities(src.CityPart5Id)))
                .ForMember(dest => dest.CityPart6NumberOfListings, opt => opt.MapFrom(src => Helpers.LayoutGetValues.GetListingsNumberForCities(src.CityPart6Id)));
            //GLOBAL SETTINGS HOME CONTROLLER

            //LISTING DETAILS PAGE
            CreateMap<Listing, ListingViewModel>()
                .ForMember(dest => dest.ImagePreview, opt => opt.MapFrom(src => src.Images.OrderBy(li => li.SortOrder).ThenBy(li => li.Id).FirstOrDefault().FileName))
                .ForMember(dest => dest.ImagePreviewPath, opt => opt.MapFrom(src => src.Images.OrderBy(li => li.SortOrder).ThenBy(li => li.Id).FirstOrDefault().FilePath))
                .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.ApplicationUser.Id))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.OrderBy(img => img.SortOrder).ThenBy(img => img.Id)));
            //LISTING DETAILS PAGE

            ///*------------------------ADMIN------------------------*/

            //DASHBOARD
            CreateMap<PropertyBuyer, BuyersViewModel>().ReverseMap();
            CreateMap<PropertyOwner, SellersViewModel>().ReverseMap();
            //DASHBOARD

            //GLOBAL SETTINGS FORM
            CreateMap<GlobalSettings, GlobalSettingsViewModel>()
                    .Ignore(gs => gs.CityParts);

            //GLOBAL SETTINGS EDIT
            CreateMap<GlobalSettingsViewModel, GlobalSettings>()
                    .Ignore(gs => gs.CityPart1Image)
                    .Ignore(gs => gs.CityPart2Image)
                    .Ignore(gs => gs.CityPart3Image)
                    .Ignore(gs => gs.CityPart4Image)
                    .Ignore(gs => gs.CityPart5Image)
                    .Ignore(gs => gs.CityPart6Image)
                    .Ignore(gs => gs.Image1path)
                    .Ignore(gs => gs.Image2path)
                    .Ignore(gs => gs.Image3path)
                    .Ignore(gs => gs.Image4path)
                    .Ignore(gs => gs.Image5path)
                    .Ignore(gs => gs.Image6path);
            //GLOBAL SETTINGS EDIT

            //EDIT USER
            CreateMap<ApplicationUser, AddUserViewModel>();
            //EDIT USER

            //HOME EVALUATION LIST
            CreateMap<SellerLead, SellerLeadsViewModel>();
            //HOME EVALUATION LIST

            //LISTINGS SEARCH
            CreateMap<Listing, AdminListingsListViewModel>()
                .ForMember(dest => dest.ImageName, opt => opt.MapFrom(src => src.Images.OrderBy(i => i.SortOrder).ThenBy(i => i.Id).FirstOrDefault().FileName))
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.Images.OrderBy(i => i.SortOrder).ThenBy(i => i.Id).FirstOrDefault().FilePath))
                .ForMember(dest => dest.LeaseSale, opt => opt.MapFrom(src => src.AdType.Name))
                .ForMember(dest => dest.CityPart, opt => opt.MapFrom(src => src.CityPart.Name))
                .ForMember(dest => dest.PropertyType, opt => opt.MapFrom(src => src.PropertyType.Name))
                .ForMember(dest => dest.AgentName, opt => opt.MapFrom(src => src.ApplicationUser.FirstName + " " + src.ApplicationUser.LastName));
            //LISTINGS SEARCH

            //SAVE NEW LISTING
            CreateMap<AddListingViewModel, Listing>()
                .ForMember(dest => dest.Published, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.ContractFrom, opt => opt.MapFrom(src => DateTime.ParseExact(src.ContractFrom, "dd.MM.yyyy", new CultureInfo("bs"))))
                .ForMember(dest => dest.ContractTo, opt => opt.MapFrom(src => DateTime.ParseExact(src.ContractTo, "dd.MM.yyyy", new CultureInfo("bs"))))
                .Ignore(l => l.Images)
                .Ignore(l => l.CityPart);
            //SAVE NEW LISTING

            //SAVE EDITED LISTING
            CreateMap<EditListingViewModel, Listing>()
                    .ForMember(dest => dest.ContractFrom, opt => opt.MapFrom(src => DateTime.ParseExact(src.ContractFrom, "dd.MM.yyyy", new CultureInfo("bs"))))
                    .ForMember(dest => dest.ContractTo, opt => opt.MapFrom(src => DateTime.ParseExact(src.ContractTo, "dd.MM.yyyy", new CultureInfo("bs"))))
                    .ForMember(dest => dest.Published, opt => opt.MapFrom(src => DateTime.ParseExact(src.Published, "dd.MM.yyyy", new CultureInfo("bs"))))
                    .Ignore(l => l.Images)
                    .Ignore(l => l.CityPart);
            //SAVE EDITED LISTING

            //EDIT LISTING
            CreateMap<Listing, EditListingViewModel>()
                    .ForMember(dest => dest.Published, opt => opt.MapFrom(src => src.Published.ToString("dd.MM.yyyy")))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => (decimal)src.Price))
                    .ForMember(dest => dest.ContractFrom, opt => opt.MapFrom(src => src.ContractFrom.ToString("dd.MM.yyyy")))
                    .ForMember(dest => dest.ContractTo, opt => opt.MapFrom(src => src.ContractTo.ToString("dd.MM.yyyy")))
                    .ForMember(dest => dest.CityPartName, opt => opt.MapFrom(src => src.CityPart.Name))
                    .ForMember(dest => dest.EditImagesList, opt => opt.MapFrom(src => src.Images.OrderBy(limg => limg.SortOrder).ThenBy(i => i.Id).ToList()));
            //EDIT LISTING

            //BUYER
            CreateMap<AddAsSoldViewModel, PropertyBuyer>();
            //BUYER
        }
    }

    public static class AutomapperExtension
    {
        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>
            (this IMappingExpression<TSource, TDestination> map, Expression<Func<TDestination, object>> selector)
        {
            map.ForMember(selector, config => config.Ignore());
            return map;
        }
    }
}