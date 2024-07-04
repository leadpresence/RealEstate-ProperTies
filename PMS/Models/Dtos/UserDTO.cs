using System;
using PMS.Models.User;
using System.Text.Json.Serialization;

namespace PMS.Models.Dtos
{
	public class UserDTO{

        public int Id { get; set; }
        public string UserName { get; set; }
        public required string Title { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        //public Role Role { get; set; }
        public List<UserProperty> LikedProperties { get; set; }

        [JsonIgnore]
        public required string PasswordHash { get; set; }

    }

    
}

