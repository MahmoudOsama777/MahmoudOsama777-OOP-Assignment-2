using PatternsLab.Problems.Builder;
using PatternsLab.Problems.Prototype;
using PatternsLab.Problems.Singleton;
using System.Diagnostics;
using System.Xml.Linq;

Console.WriteLine("=== SINGLETON: BEFORE ===\n");

var db = new DatabaseService();
var ui = new UiService();

Console.WriteLine();

db.Config.Theme = "Dark";
Console.WriteLine("Admin changed theme to Dark.");

ui.Render();

Console.WriteLine($"\nSame config object? {ReferenceEquals(db.Config, ui.Config)}");
Console.WriteLine($"Times config was loaded from disk: {AppConfig.LoadCount}");

//Console.WriteLine("\n=== PROTOTYPE: BEFORE ===\n");

//var sw = Stopwatch.StartNew();
//var army = new List<Enemy>();
//for (int i = 1; i <= 5; i++)
//{
//    var orc = new Orc();
//    orc.Name = $"Orc-{i}";
//    army.Add(orc);
//}
//Console.WriteLine($"Created 5 orcs in {sw.ElapsedMilliseconds} ms\n");

//Enemy original = new Orc();
//original.Name = "Boss Orc";
//Enemy copy = EnemyCopyHelper.CopyEnemy(original);

//Console.WriteLine($"\nOriginal model id: {original.ModelId}");
//Console.WriteLine($"Copy model id:     {copy.ModelId}");

//copy.Weapon.Damage = 999;
//Console.WriteLine($"\nWe changed the COPY's weapon damage to 999.");
//Console.WriteLine($"Original's weapon damage is now: {original.Weapon.Damage}");

//copy.Abilities.Add("Fire Breath");
//Console.WriteLine($"Original abilities: {string.Join(", ", original.Abilities)}");


Console.WriteLine("\n=== PROTOTYPE: After ===\n");

var prototypeNames = new Dictionary<string, Enemy>();

var sw = Stopwatch.StartNew();
var army = new List<Enemy>();
for (int i = 1; i <= 5; i++)
{
    var orc = new Orc();
    orc.Name = $"Orc-{i}";
    army.Add(orc);
}
Console.WriteLine($"Created 5 orcs in {sw.ElapsedMilliseconds} ms\n");

Enemy original = new Orc();
original.Name = "Boss Orc";
prototypeNames.Add(original.Name, original);    

Enemy copy = (Enemy)prototypeNames[original.Name].Clone();


Console.WriteLine($"\nOriginal model id: {original.ModelId}");
Console.WriteLine($"Copy model id:     {copy.ModelId}");

copy.Weapon.Damage = 999;
Console.WriteLine($"\nWe changed the COPY's weapon damage to 999.");
Console.WriteLine($"Original's weapon damage is now: {original.Weapon.Damage}");

copy.Abilities.Add("Fire Breath");
Console.WriteLine($"Original abilities: {string.Join(", ", original.Abilities)}");

Console.WriteLine("\n=== BUILDER: BEFORE ===\n");
Console.WriteLine(RegistrationCallSites.CreateLiveStudentUgly());
Console.WriteLine(RegistrationCallSites.CreateVideosOnlyUgly());

Console.WriteLine("\n=== BUILDER: AFTER ===\n");
Console.WriteLine(RegistrationCallSites.CreateLiveStudent());
Console.WriteLine(RegistrationCallSites.CreateVideosOnly());