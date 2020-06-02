using System;
using System.Collections.Generic;
using System.Linq;
using XFTest.Helpers;
using XFTest.Services;

namespace XFTest.Models
{
    public class CleaningList
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public int TimeInMinutes { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime StartTime { get; set; }
        public string ExpectedTime { get; set; }
        public string Address { get; set; }
        public string Distance { get; set; }
        public string TaskStatus { get; set; }

        public List<CleaningList> GetCleaningData()
        {
            Coordinates currentLocation = null;
            List<CleaningList> taskList = new List<CleaningList>();

            var cleaningData = new CleaningTaskService().GetCleaningTasks();

            foreach (var cd in cleaningData.data)
            {
                CleaningList cleanTask = new CleaningList();
                cleanTask.Name = $"{cd.houseOwnerFirstName} {cd.houseOwnerLastName}";
                cleanTask.Address = cd.houseOwnerAddress;
                cleanTask.StartTime = cd.startTimeUtc;
                cleanTask.ExpectedTime = (cd.expectedTime != null) ? $" / {cd.expectedTime.Replace('/', '-')}" : "";

                if (currentLocation == null)
                {
                    currentLocation = new Coordinates(cd.houseOwnerLatitude, cd.houseOwnerLongitude);
                }

                cleanTask.Distance = currentLocation.DistanceTo(new Coordinates(cd.houseOwnerLatitude, cd.houseOwnerLongitude), UnitOfLength.Kilometers).ToString("0.00");

                currentLocation = new Coordinates(cd.houseOwnerLatitude, cd.houseOwnerLongitude);

                cleanTask.TaskStatus = cd.visitState;

                cleanTask.Title = string.Join(", ", cd.tasks.Select(x => x.title));

                cleanTask.TimeInMinutes = cd.tasks.Sum(t => t.timesInMinutes);

                taskList.Add(cleanTask);
            }

            return taskList;
        }

        public List<CleaningList> GetCleaningData(DateTime startDate)
        {
            List<CleaningList> taskList = this.GetCleaningData();
            return taskList.Where(x => x.StartTime.Date.Equals(startDate.Date)).ToList();
        }
    }
}
