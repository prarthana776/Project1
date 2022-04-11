using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class Program
    {
        static void Main(string[] args)
        {
start:       Console.Write("Enter 1.To add teacher 2.To Remove a teacher 3.Display all teachers:");
            int choice = Convert.ToInt32(Console.ReadLine());
            Teachers teachers = new Teachers();
            switch (choice)
            {
                case 1:
                    Console.Write("Enter the Teacher's Id:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the Teacher's Name:");
                    string Name = Console.ReadLine();
                    Console.Write("Enter the Class:");
                    int Class = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the Section:");
                    string Section = Console.ReadLine();
                    var flag = teachers.AddTeacher(new TeacherDetails { Id = id, Name = Name, Class = Class, Section = Section }, true);
                    if (flag)
                    {
                        Console.WriteLine("Teachers Added Succesfully");
                    }
                    break;
                case 2:
                    Console.Write("Enter Teacher's Id to Remove:");
                    int ID1 = Convert.ToInt32(Console.ReadLine());
                    var flag1 = teachers.RemoveTeacher(ID1);
                    if (flag1)
                    {
                        Console.WriteLine("Teacher Removed Successfully");
                    }
                    break;
                case 3:
                    teachers.PrintAllTeachers();

                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
            Console.WriteLine("Do You Want to Continue:(yes/no)?");
            string response = Console.ReadLine();
            if (response.ToLowerInvariant() == "yes")
            {
                goto start;
            }

            Console.ReadLine();
        }
    }
}
