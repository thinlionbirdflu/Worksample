using System;

namespace WorkSample.ClassLibrary.Entities
{
    public class Task
    {
        public string Description { get; set; }

        public bool IsComplete { get; set; }

        public string Assignee { get; set; }

        public DateTime DueDate { get; set; }
    }
}