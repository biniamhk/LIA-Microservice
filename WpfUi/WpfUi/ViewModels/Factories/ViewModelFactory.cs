using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUi.State.Navigators;
using WpfUi.ViewModels.ModalViewModels;

namespace WpfUi.ViewModels.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<MapViewModel> _createMapViewModel;
        private readonly CreateViewModel<SettingsViewModel> _createSettingViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<TimePlanerViewModel> _timePlanerViewModel;
        private readonly CreateViewModel<SupportViewModel> _creteSupportViewModel;


        private readonly CreateViewModel<NavigationBarViewModel> _createNavigationBarViewModel;
        private readonly CreateViewModel<RightPanelViewModel> _createRightPanelViewModel;

        private readonly CreateViewModel<CreateTimePlanModaViewModel> _createTimePlanModal;


        public ViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel,
        CreateViewModel<MapViewModel> createMapViewModel,
        CreateViewModel<SettingsViewModel> createSettingViewModel,
        CreateViewModel<LoginViewModel> createLoginViewModel,
        CreateViewModel<TimePlanerViewModel> timePlanerViewModel,
        CreateViewModel<SupportViewModel> creteSupportViewModel,
        CreateViewModel<NavigationBarViewModel> createNavigationBarViewModel,
        CreateViewModel<RightPanelViewModel> createRightPanelViewModel,
        CreateViewModel<CreateTimePlanModaViewModel> createTimePlanModal)
        {
            _createHomeViewModel = createHomeViewModel;
            _createMapViewModel = createMapViewModel;
            _createSettingViewModel = createSettingViewModel;
            _createLoginViewModel = createLoginViewModel;
            _timePlanerViewModel = timePlanerViewModel;
            _creteSupportViewModel = creteSupportViewModel;
            _createNavigationBarViewModel = createNavigationBarViewModel;
            _createRightPanelViewModel = createRightPanelViewModel;
            _createTimePlanModal = createTimePlanModal;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _createHomeViewModel();

                case ViewType.Login:
                    return _createLoginViewModel();

                case ViewType.Settings:
                    return _createSettingViewModel();

                case ViewType.Map:
                    return _createMapViewModel();


                case ViewType.Timeplanner:
                    return _timePlanerViewModel();

                case ViewType.Support:
                    return _creteSupportViewModel();

                case ViewType.Navigator:
                    return _createNavigationBarViewModel();

                case ViewType.RightPanel:
                    return _createRightPanelViewModel();

                case ViewType.CreateTimePlanModal:
                    return _createTimePlanModal();

                default:
                    throw new ArgumentException("The Viewtype does not have a Viewmodel.", "viewType");
            }
        }
    }
}
