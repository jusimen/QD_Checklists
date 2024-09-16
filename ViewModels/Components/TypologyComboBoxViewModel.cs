using QD_Checklists.DbContexts;
using QD_Checklists.Models;
using QD_Checklists.Services;
using System.Collections.ObjectModel;

namespace QD_Checklists.ViewModels {
    public partial class TypologyComboBoxViewModel : ObservableObject {
        private readonly TypologyService _typologyService;

        [ObservableProperty]
        private ObservableCollection<Typology> _typologies = [];

        public TypologyComboBoxViewModel(IAppDbContextFactory dbContextFactory) {
            _typologyService = new TypologyService(dbContextFactory);
            
            List<Typology> typologysList = _typologyService.GetAllTypologiesAsync().Result;
            Typologies = new ObservableCollection<Typology>(typologysList);
        }
    }
}
