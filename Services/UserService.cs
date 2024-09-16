using Microsoft.EntityFrameworkCore;
using QD_Checklists.DbContexts;
using QD_Checklists.DTOs;
using QD_Checklists.Models;

namespace QD_Checklists.Services {
    public class UserService {
        private readonly AppDbContext _dbContext;

        public UserService(IAppDbContextFactory contextFactory) {
            _dbContext = contextFactory.CreateDbContext();
            _dbContext.Database.EnsureCreated();
        }

        // Create a new user
        public async Task CreateUserAsync(UserDTO user) {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        // Retrieve all users
        public async Task<List<User>> GetAllUsersAsync() {
            var users = await _dbContext.Users.ToListAsync();
            return users.Select(dto => ToUser(dto)).ToList();
        }

        // Retrieve a user by ID
        public async Task<User?> GetUserByIdAsync(int id) {
            var user = await _dbContext.Users.FindAsync(id);
            return user == null ? null : ToUser(user);
        }

        // Update a user
        public async Task UpdateUserAsync(UserDTO user) {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        // Delete a user
        public async Task DeleteUserAsync(int id) {
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null) {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }

        public static User ToUser(UserDTO dto) {
            return dto == null ? null : new User(dto.Id, dto.Name);
        }

        public static UserDTO ToUserDTO(User user) {
            return new UserDTO { Name = user.Name, Role = RoleService.ToRoleDTO(user.Role)};
        }
    }
}
