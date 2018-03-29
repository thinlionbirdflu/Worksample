using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkSample.ClassLibrary.Entities;
using WorkSample.ClassLibrary.Repositories;
using WorkSample.ClassLibrary.Services;

namespace WorkSample
{
    class Program
    {
        public static TaskService service;

        static void Main(string[] args)
        {
            service = new TaskService(new TaskRepository());
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
                        UpdateTaskListItem();
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
            List<Task> taskLists = service.GetAll();
            foreach (Task task in taskLists)
            {
                Console.WriteLine(string.Format("\tDescription: {0}", task.Description));
                Console.WriteLine(string.Format("\tAssignee: {0}", task.Assignee));
                Console.WriteLine(string.Format("\tDue Date: {0}", task.DueDate.ToString()));
                Console.WriteLine(string.Format("\tTask Status: {0}\n", task.IsComplete ? "Done" : "Not Done"));
            }
            MainMenu();
        }

        public static void AddItemToTaskList()
        {
            Task task = new Task();
            Console.WriteLine("Please enter a description of the task you would like completed.");
            task.Description = Console.ReadLine();
            Console.WriteLine("Please enter a name of the person who you would like to complete the task.");
            task.Assignee = Console.ReadLine();
            Console.WriteLine("Please enter the day you would like the task completed.");
            task.DueDate = DateTime.Parse(Console.ReadLine());
            service.Add(task);
            MainMenu();

        }

        public static void UpdateTaskListItem()
        {
            List<Task> taskLists = service.GetAll();
            int _option = 1;
            Console.WriteLine("Select an item from the task list that you would like to mark as complete");
            foreach (Task taskList in taskLists)
            {
                Console.WriteLine(string.Format("Task List Item #{0}", _option));
                Console.WriteLine(string.Format("\tDescription: {0}", taskList.Description));
                Console.WriteLine(string.Format("\tAssignee: {0}", taskList.Assignee));
                Console.WriteLine(string.Format("\tDue Date: {0}", taskList.DueDate.ToString()));
                Console.WriteLine(string.Format("\tTask Status: {0}\n", taskList.IsComplete ? "Done" : "Not Done"));
                _option++;
            }
            _option = CheckUserInput(Console.ReadLine());
            if (_option < taskLists.Count || _option != 0)
            {
                taskLists[_option - 1].IsComplete = true;
                service.Update(_option -1, taskLists[_option - 1]);
            }
            MainMenu();
        }

        private static int CheckUserInput(string input)
        {
            int _parsedInt;
            int.TryParse(input, out _parsedInt);
            return _parsedInt;
        }
    }
}
