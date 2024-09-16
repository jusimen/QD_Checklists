using Microsoft.EntityFrameworkCore;
using QD_Checklists.DbContexts;
using QD_Checklists.DTOs;
using QD_Checklists.Models;

namespace QD_Checklists.Services {
    public class RegionService {
        private readonly AppDbContext _dbContext;

        public RegionService(IAppDbContextFactory contextFactory) {
            _dbContext = contextFactory.CreateDbContext();
            _dbContext.Database.EnsureCreated();
        }

        // Create a new region
        public async Task CreateRegionAsync(RegionDTO region) {
            _dbContext.Regions.Add(region);
            await _dbContext.SaveChangesAsync();
        }

        // Retrieve all regions
        public async Task<List<Region>> GetAllRegionsAsync() {
            var regions = await _dbContext.Regions.ToListAsync();
            return regions.Select(dto => ToRegion(dto)).ToList();
        }

        // Retrieve a region by ID
        public async Task<Region?> GetRegionByIdAsync(int id) {
            var region = await _dbContext.Regions.FindAsync(id);
            return region == null ? null : ToRegion(region);
        }

        // Update a region
        public async Task UpdateRegionAsync(RegionDTO region) {
            _dbContext.Regions.Update(region);
            await _dbContext.SaveChangesAsync();
        }

        // Delete a region
        public async Task DeleteRegionAsync(int id) {
            var region = await _dbContext.Regions.FindAsync(id);
            if (region != null) {
                _dbContext.Regions.Remove(region);
                await _dbContext.SaveChangesAsync();
            }
        }

        private static Region ToRegion(RegionDTO dto) {
            return new Region(dto.Id, dto.Name);
        }

        public static RegionDTO ToRegionDTO(Region region) {
            return new RegionDTO { Name = region.Name };
        }
    }
}

