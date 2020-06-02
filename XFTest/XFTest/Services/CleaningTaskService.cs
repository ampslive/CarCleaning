using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using XFTest.Models;

namespace XFTest.Services
{
    public class CleaningTaskService
    {
        public CleaningResponse GetCleaningTasks()
        {
            CleaningResponse cleaningData;

            //Retrieve Data from Json File
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(CleaningList)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("XFTest.XF-Test-Json");

            try
            {
                using (var reader = new System.IO.StreamReader(stream))
                {

                    var json = reader.ReadToEnd();
                    cleaningData = JsonConvert.DeserializeObject<CleaningResponse>(json);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return cleaningData;
        }
    }
}
