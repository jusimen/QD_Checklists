using Microsoft.EntityFrameworkCore;
using QD_Checklists.DbContexts;
using QD_Checklists.DTOs;
using QD_Checklists.Models;

namespace QD_Checklists.Services {
    public class DivisionService {
        private readonly AppDbContext _dbContext;

        public DivisionService(IAppDbContextFactory contextFactory) {
            _dbContext = contextFactory.CreateDbContext();
            _dbContext.Database.EnsureCreated();
        }

        // Create a new division
        public async Task CreateDivisionAsync(DivisionDTO division) {
            _dbContext.Divisions.Add(division);
            await _dbContext.SaveChangesAsync();
        }

        // Retrieve all divisions
        public async Task<List<Division>> GetAllDivisionsAsync() {
            var divisions = await _dbContext.Divisions.ToListAsync();
            return divisions.Select(dto => ToDivision(dto)).ToList();
        }

        // Retrieve a division by ID
        public async Task<Division?> GetDivisionByIdAsync(int id) {
            var division = await _dbContext.Divisions.FindAsync(id);
            return division == null ? null : ToDivision(division);

        }

        // Update a division
        public async Task UpdateDivisionAsync(DivisionDTO division) {
            _dbContext.Divisions.Update(division);
            await _dbContext.SaveChangesAsync();
        }

        // Delete a division
        public async Task DeleteDivisionAsync(int id) {
            var division = await _dbContext.Divisions.FindAsync(id);
            if (division != null) {
                _dbContext.Divisions.Remove(division);
                await _dbContext.SaveChangesAsync();
            }
        }

        private static Division ToDivision(DivisionDTO dto) {
            return new Division(dto.Id, dto.Name);
        }

        public static DivisionDTO ToDivisionDTO(Division division) {
            return new DivisionDTO { Name = division.Name };
        }
    }
}
