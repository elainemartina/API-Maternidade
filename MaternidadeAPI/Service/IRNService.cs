using MaternidadeAPI.DBOs;
using MaternidadeAPI.Models;
using System.Threading.Tasks;

namespace MaternidadeAPI.Service
{
    public interface IRNService
    {
        Task<RNModel> GetByIdRn(int Id);
        Task<List<RNModel>> GetAllRn();
        Task DeleteRn(int Id);
        Task<RNModel> UpdateRn(DTORN request, int Id);
    }
}
