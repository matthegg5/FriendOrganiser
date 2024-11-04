using FriendOrganiser.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendOrganiserUI.Data
{
    public interface IFriendDataService
    {
        Task<IEnumerable<Friend>> GetAll();
    }
}