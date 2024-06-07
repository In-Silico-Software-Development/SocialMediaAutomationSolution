using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AdPerformance : Entity<Guid>
{
    public Guid AdGuid { get; set; }
    public Ad Ad { get; set; }
    public int Impressions { get; set; }
    public int Clicks { get; set; }
    public int Conversions { get; set; }
    public decimal Cost { get; set; }
    public DateTime Date { get; set; }
}

