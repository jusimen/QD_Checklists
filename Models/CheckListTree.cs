namespace QD_Checklists.Models {
    public class ChecklistTreeProject {
        public required string ProjectNumber { get; set; }
        public List<ChecklistTreeOrder> Orders { get; set; } = new List<ChecklistTreeOrder>();
    }

    public class ChecklistTreeOrder {
        public required string OrderName { get; set; }
        public List<ChecklistTreeArea> Areas { get; set; } = new List<ChecklistTreeArea>();
    }

    public class ChecklistTreeArea {
        public required string AreaName { get; set; }
        public List<ChecklistTreeDivision> Divisions { get; set; } = new List<ChecklistTreeDivision>();
    }

    public class ChecklistTreeDivision {
        public required string DivisionName { get; set; }
        public List<ChecklistTreeComponent> Components { get; set; } = new List<ChecklistTreeComponent>();
    }

    public class ChecklistTreeComponent {
        public required string ComponentName { get; set; }
    }

}
