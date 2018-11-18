using System.Threading.Tasks;

namespace KingPim.Data.DataAccess
{
    public interface IRoleSeed
    {
        Task<bool> CreateRoleIfEmpty();
    }
}
