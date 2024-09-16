namespace QD_Checklists.Models {
    public class Area(int id, string name) {
        public int Id { get; set; } = id;
        public string Name { get; } = name;
    }
}
