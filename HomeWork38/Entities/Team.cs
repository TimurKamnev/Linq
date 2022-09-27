using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork38.Entities;

public class Team
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Titles { get; set; }
    public Coach Coach { get; set; }
    public int CoachId { get; set; }
    public League? League { get; set; }
    public int LeagueId { get; set; }
    public ICollection<Player> Players { get; set; }
}
