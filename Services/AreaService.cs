using Microsoft.EntityFrameworkCore;
using QD_Checklists.DbContexts;
using QD_Checklists.DTOs;
using QD_Checklists.Models;

namespace QD_Checklists.Services {
    public class AreaService {
        private readonly AppDbContext _dbContext;

        public AreaService(IAppDbContextFactory dbContextFactory) {
            _dbContext = dbContextFactory.CreateDbContext();
            _dbContext.Database.EnsureCreated();
        }

        // Create a new area
        public async Task CreateAreaAsync(AreaDTO area) {
            _dbContext.Areas.Add(area);
            await _dbContext.SaveChangesAsync();
        }

        // Retrieve all areas
        public async Task<List<Area>> GetAllAreasAsync() {
            var areas = await _dbContext.Areas.ToListAsync();
            return areas.Select(dto => ToArea(dto)).ToList();
        }

        // Retrieve a area by ID
        public async Task<Area?> GetAreaByIdAsync(int id) {
            var area = await _dbContext.Areas.FindAsync(id);
            return area == null ? null : ToArea(area);
        }

        // Update a area
        public async Task UpdateAreaAsync(AreaDTO area) {
            _dbContext.Areas.Update(area);
            await _dbContext.SaveChangesAsync();
        }

        // Delete a area
        public async Task DeleteAreaAsync(int id) {
            var area = await _dbContext.Areas.FindAsync(id);
            if (area != null) {
                _dbContext.Areas.Remove(area);
                await _dbContext.SaveChangesAsync();
            }
        }

        private static Area ToArea(AreaDTO dto) {
            return new Area(dto.Id, dto.Name);
        }

        public static AreaDTO ToAreaDTO(Area area) {
            return new AreaDTO { Name = area.Name };
        }
    }
}
