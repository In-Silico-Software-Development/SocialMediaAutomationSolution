using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Ad : Entity<Guid>
{
    public string Platform { get; set; }
    public string Content { get; set; }
    public DateTime ScheduledTime { get; set; }
    public bool IsPublished { get; set; }
    public Guid CampaignGuid { get; set; }
    public Campaign Campaign { get; set; }
    public ICollection<AdPerformance> Performances { get; set; }
}
