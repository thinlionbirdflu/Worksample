using System.Collections.Generic;
using System.Linq;
using WorkSample.ClassLibrary.Entities;
using WorkSample.ClassLibrary.RepositoryInterfaces;

namespace WorkSample.ClassLibrary.Services
{
    public class TasksService
    {
        private ITasksRepository _repository;

        public TasksService(ITasksRepository taskListRepository)
        {
            this.Repository = taskListRepository;
        }

        public ITasksRepository Repository
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

        public void Add(Tasks task)
        {
            this.Repository.Add(task);
        }

        public void Update(int id, Tasks task)
        {
            this.Repository.Update(id, task);
        }

        public List<Tasks> GetAll()
        {
            return this.Repository.GetAll();
        }

        public List<Tasks> GetAllTasksMarkedAsDone()
        {
            return this.Repository.GetAll().Where(t => t.IsComplete).ToList();
        }

        public List<Tasks> GetAllTasksMarkedAsNotDone()
        {
            return this.Repository.GetAll().Where(t => !t.IsComplete).ToList();
        }
    }
}