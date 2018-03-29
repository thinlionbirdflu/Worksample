using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSample.ClassLibrary.Entities;
using WorkSample.ClassLibrary.Repositories;
using WorkSample.ClassLibrary.Services;

namespace WorkSample
{
    class Program
    {
        public static TaskListService service;

        static void Main(string[] args)
        {
            service = new TaskListService(new TaskListRepository());
            MainMenu();
        }

        public static void MainMenu()
        {
            string _menuChoice = string.Empty;
            bool _errorPresent = false;
            do
            {
                Console.WriteLine("Please select an option to start using your new task list system");
                Console.WriteLine("\t1. View items in your task list");
                Console.WriteLine("\t2. Add new item to your task list");
                Console.WriteLine("\t3. Mark an item in your task list complete");
                Console.WriteLine("\t4. Exit Program");
                _menuChoice = Console.ReadLine();

                switch (_menuChoice)
                {
                    case "1":
                        _errorPresent = false;
                        ViewTaskList();
                        break;
                    case "2":
                        AddItemToTaskList();
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    default:
                        _errorPresent = true;
                        Console.WriteLine(string.Format("Sorry, but {0} is not a valid menu option. Please select a valid menu option.", _menuChoice));
                        break;

                }
            } while (_errorPresent);
        }

        public static void ViewTaskList()
        {
            List<TaskList> taskLists = service.GetAll();
            foreach (TaskList taskList in taskLists)
            {
                Console.WriteLine(string.Format("\tDescription: {0}", taskList.Description));
                Console.WriteLine(string.Format("\tAssignee: {0}", taskList.Assignee));
                Console.WriteLine(string.Format("\tDue Date: {0}", taskList.DueDate.ToString()));
                Console.WriteLine(string.Format("\tTask Status: {0}", taskList.IsComplete ? "Done" : "Not Done"));
            }
        }

        public static void AddItemToTaskList()
        {
            TaskList taskList = new TaskList();
            Console.WriteLine("Please enter a description of the task you would like completed.");
            taskList.Description = Console.ReadLine();
            Console.WriteLine("Please enter a name of the person who you would like to complete the task.");
            taskList.Assignee = Console.ReadLine();
            Console.WriteLine("Please enter the day you would like the task completed.");
            taskList.DueDate = DateTime.Parse(Console.ReadLine());
            service.Add(taskList);
            MainMenu();

        }
    }
}
