using QD_Checklists.DbContexts;
using QD_Checklists.Models;
using QD_Checklists.Services;
using System.Collections.ObjectModel;

namespace QD_Checklists.ViewModels {
    public partial class PhaseComboBoxViewModel : ObservableObject {
        private readonly PhaseService _phaseService;

        [ObservableProperty]
        private ObservableCollection<Phase> _phases = [];

        public PhaseComboBoxViewModel(IAppDbContextFactory dbContextFactory) {
            _phaseService = new PhaseService(dbContextFactory);
            
            List<Phase> phasesList = _phaseService.GetAllPhasesAsync().Result;
            Phases = new ObservableCollection<Phase>(phasesList);
        }
    }
}
