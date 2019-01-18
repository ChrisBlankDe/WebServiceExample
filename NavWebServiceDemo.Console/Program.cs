using System;
using System.Globalization;
using NavWebServiceDemo.Console.NavJobListService;



namespace NavWebServiceDemo.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            NavService.UserName = "xxx";
            NavService.Password = "xxx";

            #region ShowCompanies
            ConsoleHelper.WriteHeadLine("Show Companies");
            var companies = NavService.SystemServicePortClient().Companies();
            foreach (string company in companies)
            {
                System.Console.WriteLine("Company: " + company);
            }
            #endregion

            #region ReadAllJobs
            ConsoleHelper.WriteHeadLine("Read All Jobs");
            var allJobs = NavService.JobListPortClient().ReadMultiple(null, null, 0);
            foreach (var specificJob in allJobs)
            {
                System.Console.WriteLine(specificJob.No + "---" + specificJob.Description + "---" + specificJob.Bill_to_Customer_No);
            }
            #endregion

            #region ReadFilteredJobs
            ConsoleHelper.WriteHeadLine("Read Filtered Jobs");
            var readFilter = new Job_List_Filter[]
            {
                new Job_List_Filter()
                {
                    Field = Job_List_Fields.Bill_to_Customer_No,
                    Criteria = "50000"
                }
            };
            var filteredJobs = NavService.JobListPortClient().ReadMultiple(readFilter, null, 0);
            foreach (var filteredJob in filteredJobs)
            {
                System.Console.WriteLine(filteredJob.No + "---" + filteredJob.Description + "---" + filteredJob.Bill_to_Customer_No);
            }
            #endregion

            #region CreateJob
            ConsoleHelper.WriteHeadLine("Create Job");
            var newJob = new Job_List
            {
                Description = "Awesome Project",
                Bill_to_Customer_No = "30000",
                Creation_Date = DateTime.Today,
                Creation_DateSpecified = true //when setting a date,dec,int, ... field, there is *Specified field you have to Set to true
            };
            NavService.JobListPortClient().Create(ref newJob);
            System.Console.WriteLine(newJob.No + "---" + newJob.Description + "---" + newJob.Creation_Date.Date);//PK is used from Nos
            #endregion

            #region UpdateJob
            ConsoleHelper.WriteHeadLine("Update Jobs");
            var jobToUpdate = NavService.JobListPortClient().Read(@"BÄDERWELT, 10 KR"); //Read by Primary Key
            System.Console.WriteLine("Old Description: " + jobToUpdate.Description);
            jobToUpdate.Description = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            NavService.JobListPortClient().Update(ref jobToUpdate);
            System.Console.WriteLine("New Description: " + jobToUpdate.Description);
            #endregion

            #region RemoveJob
            ConsoleHelper.WriteHeadLine("Remove Jobs");
            var removeFilter = new Job_List_Filter[]
            {
                new Job_List_Filter()
                {
                    Field = Job_List_Fields.Bill_to_Customer_No,
                    Criteria = "30000"
                }
            };
            var filteredJobsToRemove = NavService.JobListPortClient().ReadMultiple(removeFilter, null, 0);
            foreach (var filteredJobToRemove in filteredJobsToRemove)
            {
                NavService.JobListPortClient().Delete(filteredJobToRemove.Key);
            }
            #endregion

            #region CallingAnExtensionFunction
            ConsoleHelper.WriteHeadLine("Calling A nExtension Function");
            var job = NavService.JobListPortClient().Read(@"BÄDERWELT, 10 KR");
            //NavService.JobListPortClient().DoAnAwesomeJob(job.Key);
            #endregion


            System.Console.ReadKey();
        }

    }
}
