namespace PatternsLab.Problems.Prototype;

public class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }
}

public interface IEnemyPrototype
{
    IEnemyPrototype Clone();
}

public class Enemy : IEnemyPrototype
{
    private string _modelData;

    public string Name { get; set; }
    public int Health { get; set; }
    public Weapon Weapon { get; set; }
    public List<string> Abilities { get; set; } = new();
    public string ModelId => _modelData;

    protected Enemy()
    {
        Console.WriteLine("   ...loading 3D model (slow)...");
        Thread.Sleep(500);
        _modelData = "MODEL_" + Guid.NewGuid().ToString("N")[..6];
    }

    private Enemy(string modelData,string name,int health, Weapon weapon,List<string> abilities)
    {
        _modelData = modelData;
        Name = name;
        Health = health;
        Weapon = new Weapon { Name = weapon.Name, Damage = weapon.Damage };
        Abilities = abilities;
    }

    public IEnemyPrototype Clone()
    {
        return new Enemy(_modelData, Name, Health, Weapon, Abilities);
    }
}

public class Orc : Enemy
{
    public Orc()
    {
        Name = "Orc";
        Health = 100;
        Weapon = new Weapon { Name = "Axe", Damage = 25 };
        Abilities.Add("Rage");
    }
}

public class Elf : Enemy
{
    public Elf()
    {
        Name = "Elf";
        Health = 70;
        Weapon = new Weapon { Name = "Bow", Damage = 18 };
        Abilities.Add("Stealth");
    }
}

public static class EnemyCopyHelper
{
    public static Enemy CopyEnemy(Enemy e)
    {
        Enemy c ;
        if (e is Orc) c = new Orc();
        else if (e is Elf) c = new Elf();
        else throw new NotSupportedException("Unknown enemy type");

        c.Name = e.Name;
        c.Health = e.Health;
        c.Weapon = e.Weapon;
        c.Abilities = e.Abilities;
        return c;
    }
}
