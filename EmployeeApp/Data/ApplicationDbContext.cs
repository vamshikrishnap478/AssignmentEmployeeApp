using EmployeeApp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EmployeeApp.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //_httpContextAccessor = httpContextAccessor;
        }
        public DbSet<Employee> Employee { get; set; }   
        public DbSet<State> State { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public DataTable ExecuteReader
        (
        string sql
        )
        {
            IDbConnection connection = Database.GetDbConnection();
            IDbCommand command = connection.CreateCommand();
            try
            {
                connection.Open();
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                IDataReader reader = command.ExecuteReader(CommandBehavior.Default);
                var dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
                //result = Convert<TType>(reader);
            }
            finally
            {
                connection.Close();
            }
            //return null;
        }
    }
}
