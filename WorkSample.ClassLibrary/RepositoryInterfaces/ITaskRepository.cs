using System.Collections.Generic;
using WorkSample.ClassLibrary.Entities;

namespace WorkSample.ClassLibrary.RepositoryInterfaces
{
    public interface ITaskRepository
    {
        void Update(int id, Task task);

        void Add(Task task);

        List<Task> GetAll();
    }
}