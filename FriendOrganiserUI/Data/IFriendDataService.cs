using FriendOrganiser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganiserUI.Data
{
    public interface IFriendDataService
    {
        Task<IEnumerable<Friend>> GetAll();
    }
}
