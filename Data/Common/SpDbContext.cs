using Constants;
using Microsoft.EntityFrameworkCore;


namespace Data.Common
{
    public partial class SpDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
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
