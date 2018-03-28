using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSample.ClassLibrary.Entities;
using WorkSample.ClassLibrary.RepositoryInterfaces;

namespace WorkSample.ClassLibrary.Services
{
    public class TaskListService
    {
        private ITaskListRepository _repository;

        public TaskListService(ITaskListRepository taskListRepository)
        {
            this.Repository = taskListRepository;
        }

        public ITaskListRepository Repository
        {
            get
            {
                return this._repository;
            }
            set
            {
                this._repository = value;
            }
        }

        public void Add(TaskList taskList)
        {
            this.Repository.Add(taskList);
        }

        public void Update(TaskList taskList)
        {
            this.Repository.Update(taskList);
        }

        public List<TaskList> GetAll()
        {
           return this.Repository.GetAll();
        }
    }
}
