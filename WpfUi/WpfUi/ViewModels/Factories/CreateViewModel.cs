using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUi.ViewModels.Factories
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;
}
