using DTO.Transport.CuentaDTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Data.ModelData
{
    public partial class SpDbContext : DbContext
    {
        public DbSet<SaldoCuentaDTO> SaldoCuentaDTO { get; set; }
        public async Task<SaldoCuentaDTO> SaldosCuenta(long id)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@Id",
                            SqlDbType =  System.Data.SqlDbType.BigInt,
                            Size = 100,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = id
                        }};
            return this.SaldoCuentaDTO.FromSqlRaw("EXEC SaldoCuenta @Id", param).AsEnumerable().Select(x => x).FirstOrDefault();
        }
    }
}
