using NArchitecture.Core.Persistence.Repositories;
using NArchitecture.Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Campaign : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Budget { get; set; }
    public Guid UserGuid { get; set; }
    public User User { get; set; }
    public ICollection<Ad> Ads { get; set; } = new List<Ad>();
}

