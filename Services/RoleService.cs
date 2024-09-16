using Microsoft.EntityFrameworkCore;
using QD_Checklists.DbContexts;
using QD_Checklists.DTOs;
using QD_Checklists.Models;

namespace QD_Checklists.Services {
    public class RoleService {
        private readonly AppDbContext _dbContext;

        public RoleService(IAppDbContextFactory contextFactory) {
            _dbContext = contextFactory.CreateDbContext();
            _dbContext.Database.EnsureCreated();
        }

        // Create a new role
        public async Task CreateRoleAsync(RoleDTO role) {
            _dbContext.Roles.Add(role);
            await _dbContext.SaveChangesAsync();
        }

        // Retrieve all roles
        public async Task<List<Role>> GetAllRolesAsync() {
            var roles = await _dbContext.Roles.ToListAsync();
            return roles.Select(dto => ToRole(dto)).ToList();
        }

        // Retrieve a role by ID
        public async Task<Role?> GetRoleByIdAsync(int id) {
            var role = await _dbContext.Roles.FindAsync(id);
            return role == null ? null : ToRole(role);
        }

        // Update a role
        public async Task UpdateRoleAsync(RoleDTO role) {
            _dbContext.Roles.Update(role);
            await _dbContext.SaveChangesAsync();
        }

        // Delete a role
        public async Task DeleteRoleAsync(int id) {
            var role = await _dbContext.Roles.FindAsync(id);
            if (role != null) {
                _dbContext.Roles.Remove(role);
                await _dbContext.SaveChangesAsync();
            }
        }

        private static Role ToRole(RoleDTO dto) {
            return new Role(dto.Id, dto.Name);
        }

        public static RoleDTO ToRoleDTO(Role role) {
            return new RoleDTO { Name = role.Name };
        }
    }
}

