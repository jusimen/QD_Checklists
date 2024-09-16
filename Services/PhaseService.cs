using Microsoft.EntityFrameworkCore;
using QD_Checklists.DbContexts;
using QD_Checklists.DTOs;
using QD_Checklists.Models;

namespace QD_Checklists.Services {
    public class PhaseService {
        private readonly AppDbContext _dbContext;

        public PhaseService(IAppDbContextFactory contextFactory) {
            _dbContext = contextFactory.CreateDbContext();
            _dbContext.Database.EnsureCreated();
        }

        // Create a new phase
        public async Task CreatePhaseAsync(PhaseDTO phase) {
            _dbContext.Phases.Add(phase);
            await _dbContext.SaveChangesAsync();
        }

        // Retrieve all phases
        public async Task<List<Phase>> GetAllPhasesAsync() {
            var phase = await _dbContext.Phases.ToListAsync();
            return phase.Select(dto => ToPhase(dto)).ToList();
        }

        // Retrieve a phase by ID
        public async Task<Phase?> GetPhaseByIdAsync(int id) {
            var phase = await _dbContext.Phases.FindAsync(id);
            return phase == null ? null : ToPhase(phase);
        }

        // Update a phase
        public async Task UpdatePhaseAsync(PhaseDTO phase) {
            _dbContext.Phases.Update(phase);
            await _dbContext.SaveChangesAsync();
        }

        // Delete a phase
        public async Task DeletePhaseAsync(int id) {
            var phase = await _dbContext.Phases.FindAsync(id);
            if (phase != null) {
                _dbContext.Phases.Remove(phase);
                await _dbContext.SaveChangesAsync();
            }
        }

        private static Phase ToPhase(PhaseDTO dto) {
            return new Phase(dto.Id, dto.Name);
        }

        public static PhaseDTO ToPhaseDTO(Phase phase) {
            return new PhaseDTO { Name = phase.Name };
        }
    }
}
