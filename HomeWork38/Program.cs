using HomeWork38.Context;
using HomeWork38.Entities;
using Microsoft.EntityFrameworkCore;


using ApplicationDbContext db = new ApplicationDbContext();
{
    League league = new League
    {
        Name = "Premier League"
    };

    League league2 = new League
    {
        Name = "La-Liga"
    };
    db.Leagues.AddRange(league, league2);
    db.SaveChanges();


    Coach coach = new Coach
    {
        Name = "Pele",
        Age = 52,
        Standing = 21
    };

    Coach coach2 = new Coach
    {
        Name = "Maradona",
        Age = 48,
        Standing = 20
    };
    db.Coaches.AddRange(coach, coach2);
    db.SaveChanges();


    Team team = new Team
    {
        Name = "Man-United",
        Titles = 12,
        LeagueId = league.Id,
        CoachId = coach.Id
    };

    Team team2 = new Team
    {
        Name = "PSG",
        Titles = 9,
        LeagueId = league2.Id,
        CoachId = coach2.Id
    };
    db.Teams.AddRange(team, team2);
    db.SaveChanges();


    Player player = new Player
    {
        FullName = "Neymar Da Silva",
        Number = 11,
        Age = 30,
        BirthOfDate = new DateTime(1992, 2, 5),
        TeamId = team2.Id
    };

    Player player2 = new Player
    {
        FullName = "Cristiano Ronaldo",
        Number = 7,
        Age = 37,
        BirthOfDate = new DateTime(1985, 2, 5),
        TeamId = team.Id
    };

    Player player3 = new Player
    {
        FullName = "Lionel Messi",
        Number = 10,
        Age = 35,
        BirthOfDate = new DateTime(1987, 6, 24),
        TeamId = team.Id
    };

    Player player4 = new Player
    {
        FullName = "Kylian Mbappe",
        Number = 12,
        Age = 23,
        BirthOfDate = new DateTime(1998, 12, 20),
        TeamId = team2.Id
    };
    db.Players.AddRange(player, player2, player3, player4);
    db.SaveChanges();

}

var players = db.Set<Player>();
var check = players
    .Where(i => i.Id > 1)
    .OrderByDescending(i => i.FullName)
    .Skip(1)
    .ToList();
foreach(var p in check)
{
    Console.WriteLine($"Имена игроков - {p.FullName} Возраст - \n {p.Age}");
}

var checkteam = db.Set<Team>();
var check1 = checkteam
    .Take(5)
    .Include(i => i.League)
    .ToList();
foreach(var t in check1)
{
    Console.WriteLine($"Название лиги - {t.League.Name} Титулы команды - 0\n {t.Titles}");
}

var checkcoach = db.Set<Coach>();
var check2 = checkcoach
    .Find(1);
Console.WriteLine(check2);


var checkLeague = db.Set<League>();
var check3 = checkLeague
    .SingleOrDefault(i => i.Name == "P");
Console.WriteLine(check3);


var players2 = db.Set<Player>();
bool check4 = players2
    .Any(i => i.Age < 35);
Console.WriteLine(check4);


var checkcoach2 = db.Set<Coach>();
bool check5 = checkcoach2
    .All(s => s.Age > 40);
if (check5 == true)
{
    Console.WriteLine("Есть тренера больше 40");
}
else
    Console.WriteLine("Нет тренеров больше 40");