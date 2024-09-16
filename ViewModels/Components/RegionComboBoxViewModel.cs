using QD_Checklists.DbContexts;
using QD_Checklists.Models;
using QD_Checklists.Services;
using System.Collections.ObjectModel;

namespace QD_Checklists.ViewModels {
    public partial class RegionComboBoxViewModel : ObservableObject {
        private readonly RegionService _regionService;

        [ObservableProperty]
        private ObservableCollection<Region> _regions = [];

        public RegionComboBoxViewModel(IAppDbContextFactory dbContextFactory) {
            _regionService = new RegionService(dbContextFactory);
            
            List<Region> regionsList = _regionService.GetAllRegionsAsync().Result;
            Regions = new ObservableCollection<Region>(regionsList);
        }
    }
}
