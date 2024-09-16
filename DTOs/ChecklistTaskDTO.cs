using System.ComponentModel.DataAnnotations;

namespace QD_Checklists.DTOs
{
    public partial class ChecklistTaskDTO
    {
        [Key]
        public int Id { get; set; }
        public required string Order { get; set; }
        public required string Description { get; set; }
        public required bool? Status { get; set; }
        public ICollection<ChecklistTaskDTO>? SubTasks { get; set; }
    }
}
