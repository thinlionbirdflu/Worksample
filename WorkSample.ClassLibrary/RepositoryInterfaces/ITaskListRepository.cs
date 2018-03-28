using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
