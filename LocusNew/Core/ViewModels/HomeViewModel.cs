using System.Collections.Generic;

namespace LocusNew.Core.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<ListingsListViewModel> Listings { get; set; }
        public LeadViewModel Message { get; set; }
        public HomeGlobalSettingsViewModel GlobalSettings { get; set; }

        public HomeViewModel()
        {
            Message = new LeadViewModel();
        }
    }
}