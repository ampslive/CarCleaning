using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using XFTest.Models;

namespace XFTest.ViewModels
{
    public class CalendarViewModel : BaseViewModel
    {
        private DateTime _baseDate;
        private DateTime _selectedDate;

        public ICommand ShowTasksCommand { get; }
        public ICommand ChangeWeekCommand { get; }



        public DateTime BaseDate
        {
            get { return _baseDate; }
            set { _baseDate = value; OnPropertyChanged(); }
        }

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set { 
                _selectedDate = value; 
                OnPropertyChanged();
            }
        }

        public ObservableCollection<DateTime> Days { get; set; }
        public ObservableCollection<CleaningList> CleaningTasks { get; set; }

        public CalendarViewModel()
        {
            Days = new ObservableCollection<DateTime>();
            CleaningTasks = new ObservableCollection<CleaningList>();
            ShowTasksCommand = new Command(ShowsTasks);
            ChangeWeekCommand = new Command<string>((month) => ChangeMonth(month));
            BaseDate = new DateTime(2020, 04, 29);
            SelectedDate = BaseDate;
            SetDays(BaseDate);
            ShowsTasks();
        }

        private void SetDays(DateTime baseDate)
        {
            Days.Clear();
            var daysInMonth = DateTime.DaysInMonth(baseDate.Year, baseDate.Month);
            var startDate = new DateTime(baseDate.Year, baseDate.Month, 1);
            var lastDateOfMonth = new DateTime(baseDate.Year, baseDate.Month, daysInMonth);

            while(startDate <= lastDateOfMonth)
            {
                this.Days.Add(startDate);
                startDate = startDate.AddDays(1);
            }

        }

        private void ChangeMonth(string month)
        {
            BaseDate = BaseDate.AddMonths(Int32.Parse(month));
            SetDays(BaseDate);
        }

        private void ShowsTasks()
        {
            CleaningTasks.Clear();
            var tasks = new CleaningList().GetCleaningData(SelectedDate);
            foreach (var t in tasks)
                CleaningTasks.Add(t);
        }
    }
}
