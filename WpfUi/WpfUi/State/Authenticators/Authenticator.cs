using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfUi.Helpers;
using WpfUi.Models;

namespace WpfUi.State.Authenticators
{
    public class Authenticator : ObservableObject, IAuthenticator
    {

        private HttpClient apiClient;

        public Authenticator()
        {
            InitializeClient();
        }
        private void InitializeClient()
        {


            apiClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:3666/")
            };
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }



        private AuthenticatedUser _currentUser;
        public AuthenticatedUser CurrentUser
        {
            get
            {
                return _currentUser;

            }

            private set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
                OnPropertyChanged(nameof(IsLoggedIn));
            }

        }

        private bool _isLoggedIn;

        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set { _isLoggedIn = value; OnPropertyChanged(nameof(IsLoggedIn)); }
        }





        public async Task<bool> Login(string username, string password)
        {
            bool validLogin = false;
            try
            {

                LoginModel loginModel = new();
                loginModel.password = password;
                loginModel.email = username;

                string json = await Task.Run(() => JsonConvert.SerializeObject(loginModel));
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var httpResponse = await apiClient.PostAsync($"login", httpContent);

                if (httpResponse.IsSuccessStatusCode)
                {
                    CurrentUser = new AuthenticatedUser();
                    string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                    try
                    {
                        var result = JsonConvert.DeserializeObject<IList<AuthenticatedUser>>(jsonResponse);
                        CurrentUser = result.FirstOrDefault();
                        validLogin = true;
                        IsLoggedIn = true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Wrong Email or Password");
                        validLogin = false;
                        IsLoggedIn = false;
                    }
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Wrong Email or Password");
                validLogin = false;
            }

            return validLogin;

        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}
