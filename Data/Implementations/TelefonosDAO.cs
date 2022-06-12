using Common.Utilities;
using Data.Common;
using Data.Interfaces;
using Data.ModelData;
using DTO.Transport.TelefonosDTO;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class TelefonosDAO : ITelefonosDAO
    {
        #region props
        private readonly IRepository<TiposTelefono> TiposTelefono;
        private readonly IRepository<TelefonosPersona> TelefonosPersona;
        #endregion
        #region ctor
        public TelefonosDAO(IRepository<TiposTelefono> tiposTelefono, IRepository<TelefonosPersona> telefonosPersona)
        {
            TiposTelefono = tiposTelefono ?? throw new ArgumentNullException(nameof(tiposTelefono));
            TelefonosPersona = telefonosPersona ?? throw new ArgumentNullException(nameof(telefonosPersona));
        }

        public async Task<ICollection<AgregarTelefonoDTO>> addTelefonos(ICollection<AgregarTelefonoDTO> request,long IdPersona)
        {
            foreach(AgregarTelefonoDTO agregarTelefonoDTO in request)
            {
                TelefonosPersona saver = new TelefonosPersona() { IdPersona = IdPersona,IdTipoTelefono= agregarTelefonoDTO.IdTipoTelefono,Telefono= agregarTelefonoDTO.Telefono };
                await TelefonosPersona.CreateAsync(saver);
            }
            ICollection<TelefonosPersona> cloneable= await TelefonosPersona.Entity.Select(x => x).Where(x=> x.IdPersona== IdPersona).ToListAsync();
            return cloneable.Clone<TelefonosPersona,AgregarTelefonoDTO>();
        }
        #endregion
        #region methods
        public async Task<ICollection<TelefonosDTO>> getAll()
        {
            ICollection<TiposTelefono> exists = await TiposTelefono.Entity.Select(x => x).ToListAsync();
            return exists.Clone<TiposTelefono, 
                TelefonosDTO>();
        }

        public async Task<bool> put(EditarTelefonoDTO request)
        {
            bool exists = await TelefonosPersona.Entity.Select(x => x).Where(x => x.IdPersona == request.IdPersona && x.IdTipoTelefono == request.IdTipoTelefono).AnyAsync();
            if (!exists)
            {
                return false;
            }
            TelefonosPersona change = request.Clone<EditarTelefonoDTO, TelefonosPersona>();
            TelefonosPersona telefonosPersona = await TelefonosPersona.Put(change);
            return (telefonosPersona != null) ? true : false;
        }
        #endregion
    }
}
