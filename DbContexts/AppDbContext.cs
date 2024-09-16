using Microsoft.EntityFrameworkCore;
using QD_Checklists.DTOs;
using QD_Checklists.Models;

namespace QD_Checklists.DbContexts {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<AreaDTO> Areas { get; set; }
        public DbSet<ComponentDTO> Components { get; set; }
        public DbSet<DivisionDTO> Divisions { get; set; }
        public DbSet<PhaseDTO> Phases { get; set; }
        public DbSet<RegionDTO> Regions { get; set; }
        public DbSet<TypologyDTO> Typologies { get; set; }
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<RoleDTO> Roles { get; set; }
        public DbSet<ChecklistDTO> Checklists { get; set; }
        public DbSet<ChecklistTaskDTO> ChecklistTasks { get; set; }
    }
}
