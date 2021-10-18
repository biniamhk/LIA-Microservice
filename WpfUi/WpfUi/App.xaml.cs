using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfUi.Helpers;
using WpfUi.Models;
using WpfUi.State.Authenticators;
using WpfUi.State.Navigators;
using WpfUi.ViewModels;
using WpfUi.ViewModels.Factories;
using WpfUi.ViewModels.ModalViewModels;
using WpfUi.Views;

namespace WpfUi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {

            IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();


            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<MainViewModel>();
            }






            base.OnStartup(e);
        }


        private IServiceProvider CreateServiceProvider()
        {

            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IApiHelper, ApiHelper>();
            services.AddSingleton<IViewModelFactory, ViewModelFactory>();
            services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<IAuthenticator, Authenticator>();
           

            services.AddSingleton<CreateViewModel<HomeViewModel>>(services =>
            {
                return () => new HomeViewModel(services.GetRequiredService<IAuthenticator>(), services.GetRequiredService<INavigator>());
            });

            services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
            {
                return () => new LoginViewModel(services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>(),
                    services.GetRequiredService<INavigator>(),
                    services.GetRequiredService<IApiHelper>(),
                    services.GetRequiredService<IViewModelFactory>());
            });

            services.AddSingleton<CreateViewModel<SettingsViewModel>>(services =>
            {
                return () => new SettingsViewModel(services.GetRequiredService<IApiHelper>(),
                    services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<INavigator>(), services.GetRequiredService<IViewModelFactory>()


                    );
            });

            services.AddSingleton<CreateViewModel<NavigationBarViewModel>>(services =>
            {
                return () => new NavigationBarViewModel(
                    services.GetRequiredService<INavigator>(),
                    services.GetRequiredService<IViewModelFactory>(),
                    services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<IApiHelper>());

            });



            services.AddSingleton<CreateViewModel<MapViewModel>>(services =>
            {
                return () => new MapViewModel(services.GetRequiredService<IApiHelper>());

            });

            services.AddSingleton<CreateViewModel<SupportViewModel>>(services =>
            {
                return () => new SupportViewModel();
            });

            services.AddSingleton<CreateViewModel<CreateTimePlanModaViewModel>>(services =>
            {
                return () => new CreateTimePlanModaViewModel(services.GetRequiredService<INavigator>(),
                    services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<IApiHelper>(),
                    services.GetRequiredService<IViewModelFactory>()
                    );
            });







            services.AddSingleton<CreateViewModel<TimePlanerViewModel>>(services =>
            {
                return () => new TimePlanerViewModel(services.GetRequiredService<IApiHelper>(),
                    services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<IViewModelFactory>(),
                    services.GetRequiredService<INavigator>()
                    );
            });

            services.AddSingleton<CreateViewModel<RightPanelViewModel>>(services =>
            {
                return () => new RightPanelViewModel(services.GetRequiredService<IAuthenticator>(), 
                    services.GetRequiredService<IApiHelper>());
            });




            services.AddScoped<MainViewModel>();
            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));


            return services.BuildServiceProvider();




        }


    }
}
