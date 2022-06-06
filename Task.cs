using System;
using System.Globalization;

namespace Task_object
{
    /*any task must have some fundamental characteristics:
        when it was assigned
        when it needs to be completed by
        perhaps a type of task?
            well thats what a derived class is retard
        
        who assigned it?
        who is it assigned to?
            i think that to support scalability in applying a task, the assignee and assigner should be implemented in a generic manner with some 


        some ideas about derived classes:
            a chore might have a location
            an assignment might have supporting documents






    when a new task is created, should the caller only pass the due date, or should it create a datetime object to pass
        is the task object resonsible for creating the datetime object, or is the caller?



    */
    interface ITask
    {
        string Assigned();
        string Due();
        TimeSpan Remaining();
    }

//potentially create a struct to hold the culture/style info for creation of a datetime object?
//encapsulate localization struct inside of each task object?
    public struct LocalizationInfo
    {
        public CultureInfo culture;
        public DateTimeStyles styles;

    }

    public class Task :  ITask
    {
        public Task(string name, string duedate_toparse)
        {
            this.lInfo.culture = CultureInfo.CreateSpecificCulture("en-US");
            this.lInfo.styles = DateTimeStyles.None;

            this.Name = name;

            if (DateTime.TryParse(duedate_toparse, lInfo.culture, lInfo.styles, out this.duedate)){Console.WriteLine("Successfully parsed due date from string");}
            else 
            {
                this.duedate = DateTime.Now;
                Console.WriteLine("Failed to parse date info from provided string, due date initialized to NOW!");
            }
            
            this.assigned = DateTime.Now; //date assigned is assumed to to be the day the task is created
            this.Completed = false;

        }//Task constructor


        //overloaded constructor to retroactively set assigned date

        public Task(string name, string duedate_toparse, string assinged_date)
        {
            this.lInfo.culture = CultureInfo.CreateSpecificCulture("en-US");
            this.lInfo.styles = DateTimeStyles.None;

            this.Name = name;

            if (DateTime.TryParse(duedate_toparse, lInfo.culture, lInfo.styles, out this.duedate)) {Console.WriteLine("Successfully parsed due date from string");}
            else 
            {
                this.duedate = DateTime.Now;
                Console.WriteLine("Failed to parse date info from provided string, due date initialized to NOW!");
            }

            if(DateTime.TryParse(assinged_date,lInfo.culture,lInfo.styles, out this.assigned)) {Console.WriteLine("Successfully parsed assigned date from string");}
            else
            {
                this.assigned = DateTime.Now;
                Console.WriteLine("Failed to parse assigned date from string, assigned date initialized to NOW!");
            }

            this.Completed = false;

        }//Overloaded Task constructor


        private LocalizationInfo lInfo;
        

        public string Name { get; set;}
        public bool Completed { get; set; }
        private DateTime assigned; //should be set at time object is created by default, but can be changed later
        private DateTime duedate;
        

        public string Assigned()
        {
            return assigned.Date.ToString();
        }

        public string Due()
        {
            return duedate.Date.ToString();
        }

        public TimeSpan Remaining() //return number of days before deadline
        {
            //perform calculation of duedate - assigned using date time library
            TimeSpan remaining = duedate.Subtract(DateTime.Now);
            return remaining;
        }
        
        

    }
}//namespace Task object

namespace main
{
    using Task_object;
    class TestClass
{
    static void Main(string[] args)
    {
        Task_object.Task test1 = new Task_object.Task("Test task","6/7/2022");
        Task_object.Task test2 = new Task_object.Task("second test", "6/21/22","6/1/22");


        void testfunc(Task_object.Task task)
        {
            Console.WriteLine("Task name: {0}", task.Name);
            Console.WriteLine("Date task was assigned: {0}", task.Assigned());
            Console.WriteLine("Date task is due: {0}", task.Due());
            Console.WriteLine("Amount of time remaining to complete task: {0}\n", task.Remaining());
        }

        testfunc(test1);
        testfunc(test2);
        
    }
}
}