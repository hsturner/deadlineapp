using System;
using Task_object;
using Task_user;

namespace TestClass{
class TestClass
{
    static void Main(string[] args)
    {
        Task_object.Task test1 = new Task_object.Task("Test task","6/7/2022");
        Console.WriteLine(test1.Name);
        Console.WriteLine(test1.Assigned());
        Console.WriteLine(test1.Due());
        Console.WriteLine(test1.Remaining());




        User user1 = new User ("harlan", "test passwword");
        user1.createTask("Test task via createTask function", "6/21/22");
        user1.createTask("test task 2 added to users dictionary", "6/31/2025", "5/13/2022");

        user1.allTasks();
        

    }
}
}