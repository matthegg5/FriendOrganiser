using FriendOrganiser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganiserUI.Data
{
    public class FriendDataService : IFriendDataService
    {
        public IEnumerable<Friend> GetAll()
        {
            yield return new Friend { FirstName = "Thomas", LastName = "Hubert", Email = "thomas@hubert.com", Id = 1 };
            yield return new Friend { FirstName = "Jimbo", LastName = "Hardman", Email = "jimbo@hardman.com", Id = 2 };
        }
    }
}
