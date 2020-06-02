using Prism.Navigation;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using XFTest.Models;

namespace XFTest.ViewModels
{
    public class CleaningListViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public ObservableCollection<CleaningList> CleaningTasks { get; private set; }
        public ICommand LoadTasksCommand { get; }


        public CleaningListViewModel(IDialogService dialogService, INavigationService navigationService)
        {
            CleaningTasks = RetrieveCleaningData();
            LoadTasksCommand = new Command(LoadCleaningData);
        }

        private void LoadCleaningData(object obj)
        {
            IsBusy = true;
            CleaningTasks.Clear();
            foreach (var task in RetrieveCleaningData())
                CleaningTasks.Add(task);
            IsBusy = false;
        }

        private ObservableCollection<CleaningList> RetrieveCleaningData()
        {
            var cleaningList = new CleaningList().GetCleaningData();
            ObservableCollection<CleaningList> taskList = new ObservableCollection<CleaningList>(cleaningList);

            return taskList;
        }
    }
}
