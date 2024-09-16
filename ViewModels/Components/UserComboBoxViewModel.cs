using QD_Checklists.DbContexts;
using QD_Checklists.Models;
using QD_Checklists.Services;
using System.Collections.ObjectModel;

namespace QD_Checklists.ViewModels {
    public partial class UserComboBoxViewModel : ObservableObject {
        private readonly UserService _userService;

        [ObservableProperty]
        private ObservableCollection<User> _users = [];

        public UserComboBoxViewModel(IAppDbContextFactory dbContextFactory) {
            _userService = new UserService(dbContextFactory);
            
            List<User> usersList = _userService.GetAllUsersAsync().Result;
            Users = new ObservableCollection<User>(usersList);
        }
    }
}
