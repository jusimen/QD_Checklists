using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QD_Checklists.DbContexts {
    public interface IAppDbContextFactory {
        AppDbContext CreateDbContext();
    }
}
