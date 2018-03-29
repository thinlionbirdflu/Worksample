using System.Collections.Generic;
using WorkSample.ClassLibrary.Entities;

namespace WorkSample.ClassLibrary.RepositoryInterfaces
{
    public interface ITasksRepository
    {
        void Update(int id, Tasks task);

        void Add(Tasks task);

        List<Tasks> GetAll();
    }
}