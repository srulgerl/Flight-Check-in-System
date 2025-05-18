using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public abstract class AbsRepository
    {
        private readonly string _connectionString;

        protected AbsRepository(string connectionString) { 
            _connectionString = connectionString;
        }

        protected SqliteConnection CreateConnection() { 
            return new SqliteConnection(_connectionString); 
        }

    }
}
