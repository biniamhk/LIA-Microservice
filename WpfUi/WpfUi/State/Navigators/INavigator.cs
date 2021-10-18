using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfUi.ViewModels;

namespace WpfUi.State.Navigators
{

    public enum ViewType
    {
        Home,
        Login,
        Settings,
        Map,
        Main,
        Timeplanner,
        Support,
        Navigator,
        RightPanel,
        CreateTimePlanModal
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ViewModelBase SeconderyViewModel { get; set; }
        ViewModelBase NavigatorViewModel { get; set; }
        ViewModelBase RightPanelViewModel { get; set; }
        ViewModelBase ModalViewModel { get; set; }
        bool IsModalOpen { get; set; }
        void CloseModal();
    }
}
