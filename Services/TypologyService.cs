using Microsoft.EntityFrameworkCore;
using QD_Checklists.DbContexts;
using QD_Checklists.DTOs;
using QD_Checklists.Models;

namespace QD_Checklists.Services {
    public class TypologyService {
        private readonly AppDbContext _dbContext;

        public TypologyService(IAppDbContextFactory contextFactory) {
            _dbContext = contextFactory.CreateDbContext();
            _dbContext.Database.EnsureCreated();
        }

        // Create a new typology
        public async Task CreateTypologyAsync(TypologyDTO typology) {
            _dbContext.Typologies.Add(typology);
            await _dbContext.SaveChangesAsync();
        }

        // Retrieve all typologies
        public async Task<List<Typology>> GetAllTypologiesAsync() {
            var typologies = await _dbContext.Typologies.ToListAsync();
            return typologies.Select(dto => ToTypology(dto)).ToList();
        }

        // Retrieve a typology by ID
        public async Task<Typology?> GetTypologyByIdAsync(int id) {
            var typology = await _dbContext.Typologies.FindAsync(id);
            return typology == null ? null : ToTypology(typology);
        }

        // Update a typology
        public async Task UpdateTypologyAsync(TypologyDTO typology) {
            _dbContext.Typologies.Update(typology);
            await _dbContext.SaveChangesAsync();
        }

        // Delete a typology
        public async Task DeleteTypologyAsync(int id) {
            var typology = await _dbContext.Typologies.FindAsync(id);
            if (typology != null) {
                _dbContext.Typologies.Remove(typology);
                await _dbContext.SaveChangesAsync();
            }
        }

        private static Typology ToTypology(TypologyDTO dto) {
            return new Typology(dto.Id, dto.Name);
        }

        public static TypologyDTO ToTypologyDTO(Typology typology) {
            return new TypologyDTO { Name = typology.Name };
        }
    }
}
