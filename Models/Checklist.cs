namespace QD_Checklists.Models {
    public class Checklist(int id, string name, string projectNumber, string order, Component component, User projectManager, Phase phase, Area area, Division division, User? teamLeader, Typology typology, Region regionCountry, string regulations, User reviewer, User? checker, User? approver, User? clientManager, ICollection<ChecklistTask> tasks) {
        public int Id { get; } = id;
        public string Name { get; } = name;
        public string ProjectNumber { get; } = projectNumber;
        public string Order { get; } = order;
        public Component Component { get; } = component;
        public User ProjectManager { get; } = projectManager;
        public Phase Phase { get; } = phase;
        public Area Area { get; } = area;
        public Division Division { get; } = division;
        public User? TeamLeader { get; } = teamLeader;
        public Typology Typology { get; } = typology;
        public Region RegionCountry { get; } = regionCountry;
        public string Regulations { get; } = regulations;
        public User Reviewer { get; } = reviewer;
        public User? Checker { get; } = checker;
        public User? Approver { get; } = approver ?? projectManager;
        public User? ClientManager { get; } = clientManager;
        public ICollection<ChecklistTask> Tasks { get; } = tasks;
    }
}
