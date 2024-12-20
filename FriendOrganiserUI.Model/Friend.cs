﻿using System.ComponentModel.DataAnnotations;

namespace FriendOrganiser.Model
{
    public class Friend
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
