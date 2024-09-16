
using QD_Checklists.Services;
using QD_Checklists.DbContexts;
using QD_Checklists.Models;
using System.Collections.ObjectModel;

namespace QD_Checklists.ViewModels {
    public partial class AreaComboBoxViewModel : ObservableObject {
        private readonly AreaService _areaService;

        [ObservableProperty]
        private ObservableCollection<Area> _areas = new ObservableCollection<Area>();

        [ObservableProperty]
        private Area _selectedArea;

        public AreaComboBoxViewModel(IAppDbContextFactory dbContextFactory) {
            _areaService = new AreaService(dbContextFactory);
            List<Area> areas = _areaService.GetAllAreasAsync().Result;
            Areas = new ObservableCollection<Area>(areas);
        }

        [RelayCommand]
        public void OnAreaSelected(Area area) {
            SelectedArea = area;
        }
    }
}
