using System.Threading.Tasks;

namespace KingPim.Data.DataAccess
{
    public interface IIdentitySeed
    {
        Task<bool> CreateAdminAccountIfEmpty();
    }
}
