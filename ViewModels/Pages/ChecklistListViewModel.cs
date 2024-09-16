using QD_Checklists.Services;
using QD_Checklists.Helpers;
using QD_Checklists.Models;
using System.Collections.ObjectModel;
using Wpf.Ui;
using QD_Checklists.DbContexts;
using QD_Checklists.Views.Pages;

namespace QD_Checklists.ViewModels.Pages {
    /// <summary>
    /// Represents the view model for the ChecklistList page.
    /// </summary>
    public partial class ChecklistListViewModel : ObservableObject {

        // Services
        private readonly ChecklistService _checklistService;
        private readonly INavigationService _navigationService;

        // View Model Properties
        [ObservableProperty]
        private ObservableCollection<TreeItem> _checklistsTreeItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChecklistListViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="dbContextFactory">The database context factory.</param>
        public ChecklistListViewModel(INavigationService navigationService, IAppDbContextFactory dbContextFactory) {
            _navigationService = navigationService;
            _checklistService = new ChecklistService(dbContextFactory);

            FetchChecklists();
        }

        //=== Commands ===
        [RelayCommand]
        public void BtnAddChecklist() {
            _navigationService.Navigate(typeof(ChecklistAddPage));
        }

        [RelayCommand]
        public void FetchChecklists() {
            List<Checklist> checklists = _checklistService.GetAllChecklistsAsync().Result;

            // Print checklists lenght

            //Build tree
            var hierarchyFields = new List<string> { "ProjectNumber", "Order", "Area", "Division", "Component", "Name" };
            ChecklistsTreeItems = new ObservableCollection<TreeItem>(TreeHierarchy.Build(checklists, hierarchyFields));
        }
    }
}
