namespace QD_Checklists.Models {
    public class Role(int id, string name) {

        public int Id { get; set; } = id;
        public string Name { get; } = name;
    }
}
