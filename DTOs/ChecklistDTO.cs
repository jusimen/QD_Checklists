using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QD_Checklists.DTOs {
    public class ChecklistDTO {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string ProjectNumber { get; set; }

        [Required]
        public required string Order { get; set; }

        [Required]
        public required int ComponentId { get; set; }
        [ForeignKey("ComponentId")]
        public ComponentDTO Component { get; set; }

        [Required]
        public required int ProjectManagerId { get; set; }
        [ForeignKey("ProjectManagerId")]
        public UserDTO ProjectManager { get; set; }

        [Required]
        public required int PhaseId { get; set; }
        [ForeignKey("PhaseId")]
        public PhaseDTO Phase { get; set; }

        [Required]
        public required int AreaId { get; set; }
        [ForeignKey("AreaId")]
        public AreaDTO Area { get; set; }

        [Required]
        public required int DivisionId { get; set; }
        [ForeignKey("DivisionId")]
        public DivisionDTO Division { get; set; }

        public int? TeamLeaderId { get; set; }
        [ForeignKey("TeamLeaderId")]
        public UserDTO? TeamLeader { get; set; }

        [Required]
        public required int TypologyId { get; set; }
        [ForeignKey("TypologyId")]
        public TypologyDTO Typology { get; set; }

        [Required]
        public required int RegionCountryId { get; set; }
        [ForeignKey("RegionCountryId")]
        public RegionDTO RegionCountry { get; set; }

        [Required]
        public required string Regulations { get; set; }

        [Required]
        public required int ReviewerId { get; set; }
        [ForeignKey("ReviewerId")]
        public UserDTO Reviewer { get; set; }

        public int? CheckerId { get; set; }
        [ForeignKey("CheckerId")]
        public UserDTO? Checker { get; set; }

        public int? ApproverId { get; set; }
        [ForeignKey("ApproverId")]
        public UserDTO? Approver { get; set; }

        public int? ClientManagerId { get; set; }
        [ForeignKey("ClientManagerId")]
        public UserDTO? ClientManager { get; set; }

        public ICollection<ChecklistTaskDTO>? Tasks { get; set; }
    }
}
