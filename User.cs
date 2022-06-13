using System;
using Task_object;
using crypto = System.Security.Cryptography;

namespace Task_user
{


    public interface iUser
    {
        string Name {get; set;}
        string Password {init;}
        string UID {get; init;} //all users must generate a cryptographically unique UID
    }//end iUser interface

    /*
    public struct TaskArray
    {
        public TaskArray(string id)
        {
            this.uid = id;
        }
        public string uid {get; init;}
        public Dictionary<string, Task_object.Task> tArray; //Users have a dictionary that contains their tasks, rather than an array


    }


*/
    class User : iUser
    {
        public User(string name, string password)
        {
            this.Name = name;
            this.Password = password;
            byte[] buffer = gUID();
            this.UID = System.Text.Encoding.UTF8.GetString(buffer,0,buffer.Length); //converting from byte array to string
            userTaskArray = new Dictionary<string, Task_object.Task>{};
        }
        public string Name{get;set;}
        public string Password{get; init;} //not sure how to approach making this secure, as of right now,  doesn't support changing password at later date.
        //perhaps creating a new password could be acheived by creating a new user and migrating over all the member fields to the new class instance?? idk


        public Dictionary<string, Task_object.Task> userTaskArray; //will eventually need some sort of access control on this --> getter setters?
        
        
        //private int numTasks{ get; set; }

        //only using getters and setters for rough implemenation 
        //for actual security i would need some sort of two-way hashing function? i think
        public string UID{get; init;}


        

    
        //users are able to create new tasks that belong to them
        public void createTask(string taskName,string dueDate)
        {
            Task_object.Task newTask = new Task_object.Task(taskName, dueDate);
            userTaskArray.Add(newTask.Name,newTask); //add the new task to the users dictionary of tasks
            

        }


        //overload for retroactive assigned date
        public void createTask(string taskName, string dueDate, string assignedDate)
        {
            Task_object.Task newTask = new Task_object.Task(taskName, dueDate, assignedDate);
            userTaskArray.Add(newTask.Name,newTask); //add new task to users dictionary of tasks
            
        }

        public void getTask(string taskName)
        {
            if(userTaskArray.TryGetValue(taskName, out Task_object.Task getTask))
            {
                getTask.selfReport();
            }
        }

        public void allTasks()
        {
            Console.WriteLine();
            Console.WriteLine("Displaying tasks for user: {0} ....",this.Name);
            foreach(KeyValuePair<string, Task_object.Task> task in userTaskArray)
            {
                Console.WriteLine();
                task.Value.selfReport();
            }
        }

        byte[] gUID()
        {
            byte[] bytes = crypto.RandomNumberGenerator.GetBytes(10);
            return bytes;
        }


    }

}//end namespace Task_user