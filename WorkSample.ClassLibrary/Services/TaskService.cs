using System.Collections.Generic;
using System.Linq;
using WorkSample.ClassLibrary.Entities;
using WorkSample.ClassLibrary.RepositoryInterfaces;

namespace WorkSample.ClassLibrary.Services
{
    public class TaskService
    {
        private ITaskRepository _repository;

        public TaskService(ITaskRepository taskListRepository)
        {
            this.Repository = taskListRepository;
        }

        public ITaskRepository Repository
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

        public void Add(Task task)
        {
            this.Repository.Add(task);
        }

        public void Update(int id, Task task)
        {
            this.Repository.Update(id, task);
        }

        public List<Task> GetAll()
        {
            return this.Repository.GetAll();
        }

        public List<Task> GetAllTasksMarkedAsDone()
        {
            return this.Repository.GetAll().Where(t => t.IsComplete).ToList();
        }

        public List<Task> GetAllTasksMarkedAsNotDone()
        {
            return this.Repository.GetAll().Where(t => !t.IsComplete).ToList();
        }
    }
}