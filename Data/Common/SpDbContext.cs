using Constants;
using Microsoft.EntityFrameworkCore;


namespace Data.Common
{
    public partial class SpDbContext
    {
        protected void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer(Variable.STRINGCONNECTION,
                    sqlServerOptionsAction: sqlOption =>
                    {
                        sqlOption.EnableRetryOnFailure();
                    });
            }
        }
    }
}
