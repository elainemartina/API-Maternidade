using MaternidadeAPI.DBOs;
using MaternidadeAPI.Models;

namespace MaternidadeAPI.Service
{
    public interface IMãeService
    {
        Task<MãeModel> GetByIdMãe(int Id);
        Task<List<MãeModel>> GetAllMãe();
        Task DeleteMãe(int Id);
        Task<MãeModel> UpdateMãe(int Id, DTOMãe request);
        Task UpdateHistoricoMedicoMae(int Id, string historico);
        Task<List<MãeModel>> CreateMãe(MãeModel model);//
        Task<List<RNModel>> GetRnsByMãeId(int Id);
        Task<List<MãeModel>> GetMaeByEstadoCivil();
        Task<List<MãeModel>> GetMãeByProfissão(string profissão);
        Task<List<MãeModel>> GetMaeByEtnia(string etnia);
        Task<List<RNModel>> GetRNByTipoParto(int id, string Parto);
        Task<int> CreateRn(int id, RNModel model);
        Task<List<RNModel>> GetRnByGenero(int id, string genero);
        Task<List<RNModel>> GetRnByPeso(int id, double peso);
    }
}
