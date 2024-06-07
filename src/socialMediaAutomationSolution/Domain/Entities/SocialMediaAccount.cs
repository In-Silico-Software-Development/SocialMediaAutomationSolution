using NArchitecture.Core.Persistence.Repositories;
using NArchitecture.Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class SocialMediaAccount : Entity<Guid>
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Platform { get; set; }
    public string AccessToken { get; set; }
    public string AccountName { get; set; }
}