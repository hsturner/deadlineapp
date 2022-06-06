using System;
using Task_object;

class TestClass
{
    static void Main(string[] args)
    {
        Task_object.Task test1 = new Task_object.Task("Test task","6/7/2022");
        Console.WriteLine(test1.Name);
        Console.WriteLine(test1.Assigned());
        Console.WriteLine(test1.Due());
        Console.WriteLine(test1.Remaining());
    }
}