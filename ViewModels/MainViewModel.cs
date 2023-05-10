using StudentEMS.AppData;
using StudentEMS.Command;

using System.Windows.Input;

using static StudentEMS.Constants.Constant;

namespace StudentEMS.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }

        public ICommand SelectViewCommand { get; set; }

        public MainViewModel()
        {
            SelectedViewModel = new HomeViewModel();
            CurrentView.CurrentViewName = "Home";
            SelectViewCommand = new RelayCommand(SelectCurrentView, CanSelectCurrentView);
        }

        private bool CanSelectCurrentView(object obj)
        {
            return true;
        }

        private void SelectCurrentView(object obj)
        {
            string? parameter = obj as string;

            if (parameter == NavigationItem.Home.ToString())
            {
                SelectedViewModel = new HomeViewModel();
                CurrentView.CurrentViewName = parameter;
            }
        }
    }
}
