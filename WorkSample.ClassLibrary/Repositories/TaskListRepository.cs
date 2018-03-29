using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using WorkSample.ClassLibrary.Entities;
using WorkSample.ClassLibrary.RepositoryInterfaces;

namespace WorkSample.ClassLibrary.Repositories
{
    public class TaskListRepository : ITaskListRepository
    {
        public void Add(TaskList taskList)
        {
            string json = JsonConvert.SerializeObject(taskList);
            File.AppendAllText(Config.FileLocation, json);
        }

        public List<TaskList> GetAll()
        {
            List<TaskList> _taskList = new List<TaskList>();
            using (StreamReader _streamReader = new StreamReader(Config.FileLocation))
            {
                string json = _streamReader.ReadToEnd();
                _taskList = JsonConvert.DeserializeObject<List<TaskList>>(json);
            }

            return _taskList;
        }

        public void Update(TaskList taskList)
        {
            throw new NotImplementedException();
        }
    }
}