using QD_Checklists.DbContexts;
using QD_Checklists.Models;
using QD_Checklists.Services;
using System.Collections.ObjectModel;

namespace QD_Checklists.ViewModels {
    public partial class ComponentComboBoxViewModel : ObservableObject {
        private readonly ComponentService _componentService;

        [ObservableProperty]
        private ObservableCollection<Component> _components = [];

        public ComponentComboBoxViewModel(IAppDbContextFactory dbContextFactory) {
            _componentService = new ComponentService(dbContextFactory);
            
            List<Component> componentsList = _componentService.GetAllComponentsAsync().Result;
            Components = new ObservableCollection<Component>(componentsList);
        }
    }
}
