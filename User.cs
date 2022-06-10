using System;
using Task_object;
using crypto = System.Security.Cryptography;

namespace Task_user
{


    public interface iUser
    {
        string Name {get; set;}
        string Password {init;}
        byte[] UID {get; init;} //all users must generate a cryptographically unique UID
    }//end iUser interface

    public struct TaskArray
    {
        public TaskArray(byte[] uid)
        {

        }

        public Task_object.Task[] tArray;


    }

    class User : iUser
    {
        public User(string name, string password)
        {
            this.Name = name;
            this.Password = password;
            this.UID = gUID();
        }
        public string Name{get;set;}
        public string Password{init;} //not sure how to approach making this secure
        
        
        //private int numTasks{ get; set; }

        //only using getters and setters for rough implemenation 
        //for actual security i would need some sort of two-way hashing function? i think
        private byte[] UID{get; init;}


        

    
        //users are able to create new tasks that belong to them
        public void createTask()
        {

        }

        byte[] gUID()
        {
            byte[] bytes = crypto.RandomNumberGenerator.GetBytes(10);
            return bytes;
        }


    }

}//end namespace Task_user