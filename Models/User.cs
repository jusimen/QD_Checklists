namespace QD_Checklists.Models {
    public class User(int id, string name, Role? role = null) {
        public int Id { get; } = id;
        public string Name { get; } = name;
        public Role Role { get; } = role ?? new Role(1, "User");
    }
}
