using System.Collections.Generic;
using WorkSample.ClassLibrary.Entities;

namespace WorkSample.ClassLibrary.RepositoryInterfaces
{
    public interface ITaskListRepository
    {
        void Update(TaskList taskList);

        void Add(TaskList taskList);

        List<TaskList> GetAll();
    }
}