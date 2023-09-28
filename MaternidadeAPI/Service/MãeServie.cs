using Azure.Core;
using MaternidadeAPI.Models;
using Microsoft.EntityFrameworkCore;
using MaternidadeAPI.DBOs;

namespace MaternidadeAPI.Service
{
    public class MãeServie : IMãeService
    {
        private readonly DataContext _context;
        public MãeServie(DataContext context) { _context = context; }

        public async Task<List<MãeModel>> CreateMãe(MãeModel model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();

            return await _context.Mães.ToListAsync();
        }

        public async Task<List<MãeModel>> GetAllMãe()
        {
            return await _context.Mães.ToListAsync();
        }

        public async Task<MãeModel> GetByIdMãe(int Id)
        {
            var mãe = await _context.Mães.FirstOrDefaultAsync(m => m.Id == Id);
            if (mãe == null) return null;
            return mãe;
        }

        public async Task UpdateHistoricoMedicoMae(int Id, string historico)
        {
            var mae = await _context.Mães.FirstOrDefaultAsync(m => m.Id == Id);
            mae.HistoricoMedico = historico;
            await _context.SaveChangesAsync();
        }

        public async Task<List<MãeModel>> GetMaeByEstadoCivil()
        {
            return await _context.Mães.Where(m => (m.EstadoCivil) == "solteira").ToListAsync();
        }

        public async Task<List<MãeModel>> GetMãeByProfissão(string profissão)
        {
            return await _context.Mães.Where(m => (m.Profissão).ToLower() == profissão.ToLower()).ToListAsync();
        }

        // Get Mae By Etnia
        public async Task<List<MãeModel>> GetMaeByEtnia(string etnia)
        {
            return await _context.Mães.Where(m => (m.Etnia) == etnia).ToListAsync();
        }

        public async Task<List<RNModel>> GetRnsByMãeId(int Id)
        {
            var rns = await _context.RNs.Where(rn => rn.MãeId == Id).ToListAsync();
            if (rns == null) return null;
            return rns;
        }

        public async Task<MãeModel> UpdateMãe(int Id, DTOMãe request)
        {
            var mãe = await _context.Mães.FirstOrDefaultAsync(rn => rn.Id == Id);
            if (mãe == null) return null;

            mãe.Nome = request.Nome;
            mãe.Sobrenome = request.Sobrenome;
            mãe.Nascimento = request.Nascimento;
            mãe.RG = request.RG;
            mãe.CPF = request.CPF;
            mãe.Endereço = request.Endereço;
            mãe.EstadoCivil = request.EstadoCivil;
            mãe.Telefone = request.Telefone;
            mãe.Profissão = request.Profissão;
            mãe.Etnia = request.Etnia;
            mãe.HistoricoMedico = request.HistoricoMedico;
            await _context.SaveChangesAsync();

            return mãe;
        }

        public async Task DeleteMãe(int Id)
        {
            var mãe = await _context.Mães.FindAsync(Id);
            if (mãe != null)
            {
                _context.Remove(mãe);
                await _context.SaveChangesAsync();
            }
        }

        // Recem Nascido por Tipo de Parto

        public async Task<List<RNModel>> GetRNByTipoParto(int idMae, string parto)
        {
            var mae = await _context.Mães.FindAsync(idMae);
            var Bebes = await _context.RNs.Where(rn => rn.MãeId == idMae).Where(rn => rn.TipoParto == parto).ToListAsync();
            return Bebes;
        }

        // Criar Recem Nascido
    
        public async Task<int> CreateRn(int idMae, RNModel model)
        {
            model.MãeId = idMae;
            model.Mãe = await GetByIdMãe(idMae);
            _context.RNs.Add(model);
            return await _context.SaveChangesAsync();

        }

        // Listar Bebes por Genero

        public async Task<List<RNModel>> GetRnByGenero(int idMae, string genero)
        {
            var mae = await _context.Mães.FindAsync(idMae);
            var Bebes = await _context.RNs.Where(rn => rn.MãeId == idMae).Where(rn => rn.Genero == genero).ToListAsync();
            return Bebes;
        }

        // Listar Bebes A cima de certo Peso

        public async Task<List<RNModel>> GetRnByPeso(int idMae, double peso)
        {
            var mae = await _context.Mães.FindAsync(idMae);
            var Bebes = await _context.RNs.Where(rn => rn.MãeId == idMae).Where(rn => rn.Peso >= peso).ToListAsync();
            return Bebes;
        }

    }
}
