using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using WorkSample.ClassLibrary.Entities;
using WorkSample.ClassLibrary.RepositoryInterfaces;

namespace WorkSample.ClassLibrary.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private List<Tasks> taskList = new List<Tasks>() { new Tasks() {
        Assignee = "John",
        Description = "Take out the trash",
        DueDate = DateTime.Now} };

        public void Add(Tasks task)
        {
            this.taskList.Add(task);
        }

        public List<Tasks> GetAll()
        {
            return this.taskList;
        }

        public void Update(int id, Tasks task)
        {
            this.taskList[id] = task;
        }
    }
}