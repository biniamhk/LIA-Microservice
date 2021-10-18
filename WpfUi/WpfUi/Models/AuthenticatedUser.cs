using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUi
{
    public class AuthenticatedUser
    {
        public string Id { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public bool Locked { get; set; }
        public bool Enabled { get; set; }
        public string UserName { get; set; }

        public List<Authorities> Authorities { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool AccountNonExpired { get; set; }
        public bool AccountNonLocked { get; set; }
        public bool CredentialsNonExpired { get; set; }
    }

    public class Authorities
    {
        public string Authority { get; set; }
    }
}
