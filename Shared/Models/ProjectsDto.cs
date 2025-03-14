using System;
using System.Collections.Generic;

namespace TaskFlow.Shared.Models
{

    public class Projects
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public long OwnerId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
}