using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KingPim.Data.DataAccess
{
    public interface IRoleSeed
    {
        Task<bool> CreateRoleIfEmpty();
    }
}
