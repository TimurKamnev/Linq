using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork38.Entities;

public class Coach
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public byte Age { get; set; }
    public int Standing { get; set; }
    public Team Team { get; set; }
    public ICollection<Player> Players { get; set; }
}
