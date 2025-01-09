using System;
using System.Collections.Generic;

namespace TaskFlow.Models;

public partial class Users
{
    public long Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Comments> Comments { get; set; } = new List<Comments>();

    public virtual ICollection<Projects> Projects { get; set; } = new List<Projects>();

    public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
}
