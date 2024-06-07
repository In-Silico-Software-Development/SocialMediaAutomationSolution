using NArchitecture.Core.Persistence.Repositories;
using NArchitecture.Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Notification : Entity<Guid>
{
    public Notification()
    {
        IsRead = false;
    }

    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Message { get; set; }
    public bool IsRead { get; set; }
}
