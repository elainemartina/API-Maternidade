using MaternidadeAPI.DBOs;
using MaternidadeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace MaternidadeAPI.Service
{
    public class RNService : IRNService 
    {
        private readonly DataContext _context;
        public RNService(DataContext context) { _context = context; }

        public async Task<RNModel> GetByIdRn(int Id)
        {
            var RN =  await _context.RNs.Include(rn => rn.Mãe).FirstOrDefaultAsync(rn => rn.Id == Id);
            if (RN == null) return null;
            return RN;
        }

        public async Task<List<RNModel>> GetAllRn()
        {
            return await _context.RNs.Include(rn => rn.Mãe).ToListAsync();
        }

        public async Task<RNModel> UpdateRn(DTORN request, int Id)
        {
            var RN = await _context.RNs.Include(rn => rn.Mãe).FirstOrDefaultAsync(rn => rn.Id == Id);
            if (RN == null) return null;

            RN.Nome = request.Nome;
            RN.Genero = request.Genero;
            RN.Nascimento = request.Nascimento;
            RN.Peso = request.Peso;
            RN.Altura = request.Altura;
            RN.TipoParto = request.TipoParto;
            RN.Apgar = request.Apgar;
            RN.CondiçãoMedica = request.CondiçãoMedica;
            await _context.SaveChangesAsync();

            return RN;
        }

        public async Task DeleteRn(int Id)
        {
            var RN = await _context.RNs.FindAsync(Id);
            if (RN != null)
            {
                _context.Remove(RN);
                await _context.SaveChangesAsync();
            }

        }

    }
}
