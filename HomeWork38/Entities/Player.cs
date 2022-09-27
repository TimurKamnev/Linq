using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork38.Entities;

public class Player
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public int Number { get; set; }
    public byte Age { get; set; }
    public DateTime BirthOfDate { get; set; }
    public Coach Coach { get; set; }
    public int? CoachId { get; set; }
    public Team Team { get; set; }
    public int TeamId { get; set; }
}
