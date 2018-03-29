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
        public static TasksService service;

        /// <summary>
        /// Default main method that starts a console application
        /// </summary>
        /// <param name="args">arguments passed in via command line</param>
        static void Main(string[] args)
        {
            service = new TasksService(new TasksRepository());
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
            List<Tasks> taskLists = service.GetAll();
            foreach (Tasks task in taskLists)
            {
                DisplayTasks(task);
            }
            MainMenu();
        }

        public static void AddItemToTaskList()
        {
            Tasks task = new Tasks();
            string _input = string.Empty;
            DateTime _dateTime = new DateTime();
            bool _errorPresent = false;
            do
            {
                Console.WriteLine("Please enter a description of the task you would like completed.");
                _input = Console.ReadLine();
                task.Description = _input;
                Console.WriteLine("Please enter a name of the person who you would like to complete the task.");
                _input = Console.ReadLine();
                task.Assignee = _input;
                Console.WriteLine("Please enter the day you would like the task completed in MM/DD/YYYY format.");
                _input = Console.ReadLine();
                DateTime.TryParse(_input, out _dateTime);
                task.DueDate = _dateTime;
                _errorPresent = !task.IsValid();
                if (_errorPresent)
                {
                    Console.WriteLine("Sorry, but that was not a valid task. Please try again.");
                }

            } while (_errorPresent);
            service.Add(task);
            MainMenu();

        }

        public static void UpdateTaskListItem()
        {
            List<Tasks> taskLists = service.GetAll();
            int _option = 1;
            bool _errorPresent = false;
            string _choice = string.Empty;
            do
            {
                Console.WriteLine("Select an item from the task list that you would like to mark as complete");
                foreach (Tasks taskList in taskLists)
                {
                    Console.WriteLine(string.Format("Task List Item #{0}", _option));
                    DisplayTasks(taskList);
                    _option++;
                }
                _choice = Console.ReadLine();
                _option = CheckUserInput(_choice);
                if (_option <= taskLists.Count && _option != 0)
                {
                    taskLists[_option - 1].IsComplete = true;
                    service.Update(_option - 1, taskLists[_option - 1]);
                    _errorPresent = false;
                }
                else
                {
                    _errorPresent = true;
                    Console.WriteLine(string.Format("Sorry, but {0} is not a valid menu option. Please select a valid item in your task list.", _choice));
                }
            } while (_errorPresent);

            MainMenu();
        }

        private static int CheckUserInput(string input)
        {
            int _parsedInt;
            int.TryParse(input, out _parsedInt);
            return _parsedInt;
        }

        private static void DisplayTasks(Tasks task)
        {
            Console.WriteLine(string.Format("\tDescription: {0}", task.Description));
            Console.WriteLine(string.Format("\tAssignee: {0}", task.Assignee));
            Console.WriteLine(string.Format("\tDue Date: {0}", task.DueDate.ToString()));
            Console.WriteLine(string.Format("\tTask Status: {0}\n", task.IsComplete ? "Done" : "Not Done"));
        }
    }
}
