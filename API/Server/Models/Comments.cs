using System;
using System.Collections.Generic;

namespace TaskFlow.Server.Models
{
    public partial class Comments
    {
        public long Id { get; set; }

        public long TaskId { get; set; }

        public long UserId { get; set; }

        public string Content { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public virtual Tasks Task { get; set; } = null!;

        public virtual Users User { get; set; } = null!;
    }
}