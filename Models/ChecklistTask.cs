using System.Collections.ObjectModel;

namespace QD_Checklists.Models {
    public partial class ChecklistTask : ObservableObject {
        public required int Id { get; set; }
        public required string Order { get; set; }
        public required string Description { get; set; }
        public required bool? Status { get; set; } = false;
        public ObservableCollection<ChecklistTask> SubTasks { get; set; } = new();

        [RelayCommand]
        public void AddSubTask(string parentOrder) {

            // Get the last subtask order
            string order = parentOrder + "." + (SubTasks?.Count + 1 ?? 1);

            SubTasks.Add(new ChecklistTask { Id = SubTasks?.Count + 1 ?? 1, Description = "", Status = false, Order = order });
        }

        public bool RemoveTaskByOrder(string targetOrder) {
            // Iterate through the subtasks of the current task
            for (int i = 0; i < SubTasks.Count; i++) {
                ChecklistTask subTask = SubTasks[i];

                // If the subtask matches the target order, remove it
                if (subTask.Order == targetOrder) {
                    SubTasks.RemoveAt(i);
                    // Update the orders of remaining tasks after removal
                    UpdateOrderValues();
                    return true;
                }

                // Recursively search for the target task within the subtasks
                if (subTask.RemoveTaskByOrder(targetOrder)) {
                    // If removal is handled within a child, exit further processing
                    subTask.UpdateOrderValues();
                    return true;
                }
            }

            // Task not found at this level
            return false;
        }

        private void UpdateOrderValues() {
            // Update the order values of subtasks after a removal
            for (int i = 0; i < SubTasks.Count; i++) {
                // Split the current order to maintain the parent structure
                string[] orderParts = Order.Split('.');
                string newOrder = $"{orderParts[0]}.{i + 1}";

                // Update the order value of the subtask
                SubTasks[i].Order = newOrder;

                // Recursively update order values for nested subtasks
                SubTasks[i].UpdateOrderValues();
            }
        }
    }
}
