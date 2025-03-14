using System;
using System.Collections.Generic;

namespace TaskFlow.Shared.Models
{
    public class Tasks
    {
        public long Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public int? Priority { get; set; }

        public DateOnly? DueDate { get; set; }

        public long? ProjectId { get; set; }

        public long? AssignedTo { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}