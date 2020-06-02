using System;
using System.Collections.Generic;

namespace XFTest.Models
{
    public class CleaningResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public Datum[] data { get; set; }
        public int code { get; set; }
    }

    public class Datum
    {
        public string visitId { get; set; }
        public string homeBobEmployeeId { get; set; }
        public string houseOwnerId { get; set; }
        public bool isBlocked { get; set; }
        public DateTime startTimeUtc { get; set; }
        public DateTime endTimeUtc { get; set; }
        public string title { get; set; }
        public bool isReviewed { get; set; }
        public bool isFirstVisit { get; set; }
        public bool isManual { get; set; }
        public int visitTimeUsed { get; set; }
        public object rememberToday { get; set; }
        public string houseOwnerFirstName { get; set; }
        public string houseOwnerLastName { get; set; }
        public string houseOwnerMobilePhone { get; set; }
        public string houseOwnerAddress { get; set; }
        public string houseOwnerZip { get; set; }
        public string houseOwnerCity { get; set; }
        public float houseOwnerLatitude { get; set; }
        public float houseOwnerLongitude { get; set; }
        public bool isSubscriber { get; set; }
        public object rememberAlways { get; set; }
        public string professional { get; set; }
        public string visitState { get; set; }
        public int stateOrder { get; set; }
        public string expectedTime { get; set; }
        public List<Task> tasks { get; set; }
        public object[] houseOwnerAssets { get; set; }
        public object[] visitAssets { get; set; }
        public object[] visitMessages { get; set; }
    }

    public class Task
    {
        public string taskId { get; set; }
        public string title { get; set; }
        public bool isTemplate { get; set; }
        public int timesInMinutes { get; set; }
        public float price { get; set; }
        public string paymentTypeId { get; set; }
        public DateTime createDateUtc { get; set; }
        public DateTime lastUpdateDateUtc { get; set; }
        public object paymentTypes { get; set; }
    }

}
