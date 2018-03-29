using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using WorkSample.ClassLibrary.Entities;
using WorkSample.ClassLibrary.RepositoryInterfaces;

namespace WorkSample.ClassLibrary.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private List<Task> taskList = new List<Task>() { new Task() {
        Assignee = "John",
        Description = "Take out the trash",
        DueDate = DateTime.Now} };

        public void Add(Task task)
        {
            this.taskList.Add(task);
        }

        public List<Task> GetAll()
        {
            return this.taskList;
        }

        public void Update(int id, Task task)
        {
            this.taskList[id] = task;
        }
    }
}