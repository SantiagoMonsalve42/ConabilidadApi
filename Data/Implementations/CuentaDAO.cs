using Common.Utilities;
using Data.Common;
using Data.Interfaces;
using Data.ModelData;
using DTO.Transport.CuentaDTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Data.Implementations
{
    public class CuentaDAO : ICuentaDAO
    {
        #region props
        private readonly IRepository<Cuentum> RepoCuenta;
        private readonly IRepository<Transaccione> RepoTransacciones;
        #endregion
        #region ctor
        public CuentaDAO(IRepository<Cuentum> repoCuenta, IRepository<Transaccione> repoTransacciones)
        {
            RepoCuenta = repoCuenta ?? throw new ArgumentNullException(nameof(repoCuenta));
            RepoTransacciones = repoTransacciones ?? throw new ArgumentNullException(nameof(repoTransacciones));
        }
        #endregion
        public async Task<CuentaDTO> create(CuentaDTO request)
        {
            Cuentum create = request.Clone<CuentaDTO, Cuentum>();
            Cuentum hasCreated = await RepoCuenta.CreateAsync(create);
            if (hasCreated != null)
            {
                Transaccione firstTransaction = new Transaccione { IdCuenta = hasCreated.Id, ValorTransaccion = hasCreated.SaldoTotal, Fecha = DateTime.Now, EsPositivo= (hasCreated.SaldoTotal>=0)? true:false};
                await RepoTransacciones.CreateAsync(firstTransaction);
            }
            return hasCreated.Clone<Cuentum, CuentaDTO>();
        }

        public async Task<bool> Delete(CuentaByIdDTO request)
        {
            ICollection<Transaccione> rowExists = await (from row in RepoTransacciones.Entity where row.IdCuenta == request.Id select row).ToListAsync();
            if(rowExists.Count > 0)
            {
                await RepoTransacciones.DeleteRange(rowExists);
            }
            Cuentum cuentaExists = await (from row in RepoCuenta.Entity where row.Id == request.Id select row).FirstOrDefaultAsync();
            if(cuentaExists == null)
            {
                return false;
            }
            await RepoCuenta.Delete(cuentaExists);
            return true;
        }

        public async Task<CuentaDTO> get(CuentaByIdDTO request)
        {
            Cuentum cuentaExists = await (from row in RepoCuenta.Entity where row.PersonaId == request.Id select row).FirstOrDefaultAsync();
            if(cuentaExists == null)
            {
                return null;
            }
            CuentaDTO response = cuentaExists.Clone<Cuentum,CuentaDTO>();
            return response;
        }

        public async Task<SaldoCuentaDTO> SaldosCuenta(CuentaByIdDTO request)
        {
            SaldoCuentaDTO response= await RepoCuenta.spDbContext.SaldosCuenta(request.Id);
            
            return response;
        }
    }
}
