using Microsoft.EntityFrameworkCore;
using QD_Checklists.DbContexts;
using QD_Checklists.DTOs;
using QD_Checklists.Models;

namespace QD_Checklists.Services {
    public class ComponentService {
        private readonly AppDbContext _dbContext;

        public ComponentService(IAppDbContextFactory contextFactory) {
            _dbContext = contextFactory.CreateDbContext();
            _dbContext.Database.EnsureCreated();
        }

        // Create a new component
        public async Task CreateComponentAsync(ComponentDTO component) {
            _dbContext.Components.Add(component);
            await _dbContext.SaveChangesAsync();
        }

        // Retrieve all components
        public async Task<List<Component>> GetAllComponentsAsync() {
            var components = await _dbContext.Components.ToListAsync();
            return components.Select(dto => ToComponent(dto)).ToList();
        }

        // Retrieve a component by ID
        public async Task<Component?> GetComponentByIdAsync(int id) {
            var component = await _dbContext.Components.FindAsync(id);
            return component == null ? null : ToComponent(component);
        }

        // Update a component
        public async Task UpdateComponentAsync(ComponentDTO component) {
            _dbContext.Components.Update(component);
            await _dbContext.SaveChangesAsync();
        }

        // Delete a component
        public async Task DeleteComponentAsync(int id) {
            var component = await _dbContext.Components.FindAsync(id);
            if (component != null) {
                _dbContext.Components.Remove(component);
                await _dbContext.SaveChangesAsync();
            }
        }

        private static Component ToComponent(ComponentDTO dto) {
            return new Component(dto.Id, dto.Name);
        }

        public static ComponentDTO ToComponentDTO(Component component) {
            return new ComponentDTO { Name = component.Name };
        }
    }
}
