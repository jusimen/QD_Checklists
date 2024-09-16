using Microsoft.EntityFrameworkCore;
using QD_Checklists.DbContexts;
using QD_Checklists.DTOs;
using QD_Checklists.Models;

namespace QD_Checklists.Services {
    public class ChecklistService {
        private readonly AppDbContext _dbContext;


        public ChecklistService(IAppDbContextFactory dbContextFactory) {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        // Create a new checklist
        public async Task CreateChecklistAsync(ChecklistDTO checklist) {
            _dbContext.Checklists.Add(checklist);
            await _dbContext.SaveChangesAsync();
        }

        // Retrieve all checklists
        public async Task<List<Checklist>> GetAllChecklistsAsync() {
            try {
                var checklists = await _dbContext.Checklists
                    .Include(c => c.Component)
                    .Include(c => c.ProjectManager).ThenInclude(pm => pm.Role)
                    .Include(c => c.Phase)
                    .Include(c => c.Area)
                    .Include(c => c.Division)
                    .Include(c => c.TeamLeader).ThenInclude(tl => tl.Role)
                    .Include(c => c.Typology)
                    .Include(c => c.RegionCountry)
                    .Include(c => c.Reviewer).ThenInclude(r => r.Role)
                    .Include(c => c.Checker).ThenInclude(ch => ch.Role)
                    .Include(c => c.Approver).ThenInclude(ap => ap.Role)
                    .Include(c => c.ClientManager).ThenInclude(cm => cm.Role)
                    .ToListAsync();

                return checklists.Select(dto => ToChecklist(dto)).ToList();
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.ToString()}");
                return new List<Checklist>();
            }
        }

        // Retrieve a checklist by ID
        public async Task<Checklist?> GetChecklistByIdAsync(int id) {
            var checklist = await _dbContext.Checklists.FindAsync(id);
            return checklist == null ? null : ToChecklist(checklist);
        }

        // Update a checklist
        public async Task UpdateChecklistAsync(ChecklistDTO checklist) {
            _dbContext.Checklists.Update(checklist);
            await _dbContext.SaveChangesAsync();
        }

        // Delete a checklist
        public async Task DeleteChecklistAsync(int id) {
            var checklist = await _dbContext.Checklists.FindAsync(id);
            if (checklist != null) {
                _dbContext.Checklists.Remove(checklist);
                await _dbContext.SaveChangesAsync();
            }
        }

        private static Checklist ToChecklist(ChecklistDTO dto) {
            return new Checklist(
                dto.Id,
                dto.Name,
                dto.ProjectNumber,
                dto.Order,
                new Component(dto.Component.Id, dto.Component.Name),
                CreateUser(dto.ProjectManager)!,
                new Phase(dto.Phase.Id, dto.Phase.Name),
                new Area(dto.Area.Id, dto.Area.Name),
                new Division(dto.Division.Id, dto.Division.Name),
                CreateUser(dto.TeamLeader),
                new Typology(dto.Typology.Id, dto.Typology.Name),
                new Region(dto.RegionCountry.Id, dto.RegionCountry.Name),
                dto.Regulations,
                CreateUser(dto.Reviewer)!,
                CreateUser(dto.Checker),
                CreateUser(dto.Approver),
                CreateUser(dto.ClientManager),
                [] //TODO: Fix this
            );
        }

        private static User? CreateUser(UserDTO? userDto) {
            if (userDto == null) return null;
            return UserService.ToUser(userDto);
        }

        public static ChecklistDTO ToChecklistDTO(Checklist checklist) {
            return new ChecklistDTO {
                Name = checklist.Name,
                ProjectNumber = checklist.ProjectNumber,
                Order = checklist.Order,
                ComponentId = checklist.Component.Id,
                ProjectManagerId = checklist.ProjectManager.Id,
                PhaseId = checklist.Phase.Id,
                AreaId = checklist.Area.Id,
                DivisionId = checklist.Division.Id,
                TeamLeaderId = checklist.TeamLeader?.Id,
                TypologyId = checklist.Typology.Id,
                RegionCountryId = checklist.RegionCountry.Id,
                Regulations = checklist.Regulations,
                ReviewerId = checklist.Reviewer.Id,
                CheckerId = checklist.Checker?.Id ?? null,
                ApproverId = checklist.Approver?.Id ?? null,
                ClientManagerId = checklist.ClientManager?.Id ?? null,
            };

        }
    }
}
