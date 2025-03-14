using System;
using System.Collections.Generic;

namespace TaskFlow.Shared.Models
{
    public class Comments
    {
        public long Id { get; set; }

        public long TaskId { get; set; }

        public long UserId { get; set; }

        public string Content { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }
    }
}