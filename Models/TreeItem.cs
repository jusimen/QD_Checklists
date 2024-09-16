namespace QD_Checklists.Models {
    public class TreeItem(string name, int id) {
        public string Name { get; set; } = name;
        public int Id { get; } = id;
        public List<TreeItem> Children { get; set; } = new List<TreeItem>();
    }

}
