using QD_Checklists.DbContexts;
using QD_Checklists.Models;
using QD_Checklists.Services;
using System.Collections.ObjectModel;

namespace QD_Checklists.ViewModels {
    public partial class DivisionComboBoxViewModel : ObservableObject {
        private readonly DivisionService _divisionService;

        [ObservableProperty]
        private ObservableCollection<Division> _divisions = [];

        public DivisionComboBoxViewModel(IAppDbContextFactory dbContextFactory) {
            _divisionService = new DivisionService(dbContextFactory);
            
            List<Division> divisionsList = _divisionService.GetAllDivisionsAsync().Result;
            Divisions = new ObservableCollection<Division>(divisionsList);
        }
    }
}
