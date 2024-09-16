using QD_Checklists.DbContexts;
using QD_Checklists.Models;
using QD_Checklists.Services;
using QD_Checklists.Views.Pages;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Wpf.Ui;
using Wpf.Ui.Controls;
using MessageBox = Wpf.Ui.Controls.MessageBox;

namespace QD_Checklists.ViewModels.Pages {
    public partial class ChecklistAddViewModel : ObservableObject {
        // === Services ===
        private readonly INavigationService _navigationService;
        private readonly ChecklistService _checklistService;

        // === Properties ===
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _projectNumber;

        [ObservableProperty]
        private string _order;

        [ObservableProperty]
        private Component? _component;

        [ObservableProperty]
        private User? _projectManager;

        [ObservableProperty]
        private Phase? _phase;

        [ObservableProperty]
        private Area? _businessArea;

        [ObservableProperty]
        private Division? _division;

        [ObservableProperty]
        private User? _teamLeader;

        [ObservableProperty]
        private Typology? _typology;

        [ObservableProperty]
        private Region? _regionCountry;

        [ObservableProperty]
        private string _regulations;

        [ObservableProperty]
        private User? _reviewer;

        [ObservableProperty]
        private User? _checker;

        [ObservableProperty]
        private User? _approver;

        [ObservableProperty]
        private User? _clientManager;

        [ObservableProperty]
        private ObservableCollection<ChecklistTask> _tasks = [];

        // === Commands ===
        [RelayCommand]
        public void OnAddTask() {

            string order = (Tasks?.Count + 1 ?? 1).ToString();

            Tasks.Add(new ChecklistTask { Id = Tasks.Count, Description = "", Status = false, Order = order });
        }

        [RelayCommand]
        public void OnRemoveTask(ChecklistTask task) {
            if (Tasks.Count <= 1 && task.Order.Length <= 1) {
                return;
            }


            //If Trying to remove Root Task
            if (task.Order.Length == 1) {
                Tasks.Remove(task);
                return;
            }

            foreach (ChecklistTask t in Tasks) {
                if (t.RemoveTaskByOrder(task.Order)) {
                    return;
                }
            }
        }

        [RelayCommand]
        public async Task BtnSaveAsync() {
            // Save checklist to database
            Checklist checklist = new Checklist(
                id: 2,
                name: Name,
                projectNumber: ProjectNumber,
                order: Order,
                component: Component!,
                projectManager: ProjectManager!,
                phase: Phase!,
                area: BusinessArea!,
                division: Division!,
                teamLeader: TeamLeader,
                typology: Typology!,
                regionCountry: RegionCountry!,
                regulations: Regulations,
                reviewer: Reviewer!,
                checker: Checker,
                approver: Approver,
                clientManager: ClientManager,
                tasks: Tasks
            );

            try {
                await _checklistService.CreateChecklistAsync(ChecklistService.ToChecklistDTO(checklist));
            } catch (Exception e) {
                // Handle exception
                var messageBox = new MessageBox {
                    Title = "Error",
                    Content = $"Error: {e.Message}\n\nCallStack:{e.InnerException}",
                };

                await messageBox.ShowDialogAsync();
                return;
            }

            // Clear All Fields
            ClearAllFields();

            // Navigate back to ChecklistListPage
            _navigationService.Navigate(typeof(ChecklistListPage));
        }

        [RelayCommand]
        /// <summary>
        /// Cancel the operation and navigate back to ChecklistListPage.
        /// </summary>
        public void BtnCancel() {
            //Clear All Fields
            ClearAllFields();

            // Navigate back to ChecklistListPage
            _navigationService.Navigate(typeof(ChecklistListPage));
        }

        // === Private Methods ===

        /// <summary>
        /// Clear all fields in the page.
        /// </summary>
        private void ClearAllFields() {
            // Clear text fields
            Name = string.Empty;
            ProjectNumber = string.Empty;
            Order = string.Empty;
            Regulations = string.Empty;

            // Clear object fields
            Component = null;
            ProjectManager = null;
            Phase = null;
            BusinessArea = null;
            Division = null;
            TeamLeader = null;
            Typology = null;
            RegionCountry = null;
            Reviewer = null;
            Checker = null;
            Approver = null;
            ClientManager = null;

            // Clear collection fields
            Tasks = new ObservableCollection<ChecklistTask>();
        }

        public ChecklistAddViewModel(INavigationService navigationService, IAppDbContextFactory dbContextFactory) {
            // Initialize services
            _navigationService = navigationService;
            _checklistService = new ChecklistService(dbContextFactory);

            string order = (Tasks?.Count + 1 ?? 1).ToString();
            Tasks.Add(new ChecklistTask { Id = Tasks.Count, Description = "", Status = false, Order = order });

            BusinessArea = new Area(1, "Area 1");
            Component = new Component(1, "Component 1");
            Division = new Division(1, "Division 1");
            Phase = new Phase(1, "Phase 1");
            RegionCountry = new Region(1, "Region 1");
            Typology = new Typology(1, "Typology 1");
            Reviewer = new User(1, "Reviewer 1", new Role(1, "Role 1"));
            Checker = new User(1, "Checker 1", new Role(1, "Role 1"));
            Approver = new User(1, "Approver 1", new Role(1, "Role 1"));
            ClientManager = new User(1, "Client Manager 1", new Role(1, "Role 1"));
            ProjectManager = new User(1, "Project Manager 1", new Role(1, "Role 1"));

        }
    }
}
