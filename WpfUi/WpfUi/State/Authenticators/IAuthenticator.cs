using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUi.Models;

namespace WpfUi.State.Authenticators
{
    public interface IAuthenticator
    {
        AuthenticatedUser CurrentUser { get;  }
        bool IsLoggedIn { get; set; }


        Task<bool> Login(string username, string password);
        void Logout();


    }
}
