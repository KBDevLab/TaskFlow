using System;
using System.Collections.Generic;

namespace TaskFlow.Shared.Models
{
    public class Users
    {
        public long Id { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
}