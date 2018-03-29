using System;
using System.ComponentModel.DataAnnotations;

namespace WorkSample.ClassLibrary.Entities
{
    public class Tasks
    {
        [MaxLength(length: 250,
            ErrorMessage = "Cannot exceed length of 250 characters")]
        [Required(ErrorMessage = "Description of the task is required.")]
        public string Description { get; set; }

        public bool IsComplete { get; set; }

        [MaxLength(length: 250,
            ErrorMessage = "Cannot exceed length of 250 characters")]
        [Required(ErrorMessage = "Description of the task is required.")]
        public string Assignee { get; set; }

        [Required(ErrorMessage = "You must determine a due date for the task.")]
        public DateTime DueDate { get; set; }

        public bool IsValid()
        {
            bool _isValid = true;
            if (string.IsNullOrEmpty(this.Description))
            {
                _isValid = false;
            }

            if (string.IsNullOrEmpty(this.Assignee))
            {
                _isValid = false;
            }

            if (DueDate.Year == 1)
            {
                _isValid = false;
            }

            return _isValid;
        }
    }
}