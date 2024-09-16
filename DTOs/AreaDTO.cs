using System.ComponentModel.DataAnnotations;

namespace QD_Checklists.DTOs {
    public class AreaDTO {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
