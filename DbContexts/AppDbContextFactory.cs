using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QD_Checklists.DbContexts {
    internal class AppDbContextFactory : IAppDbContextFactory {
        private readonly string _connectionString;

        public AppDbContextFactory(string connectionString) {
            _connectionString = connectionString;
        }

        public AppDbContext CreateDbContext() {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new AppDbContext(options);
        }
    }
}
