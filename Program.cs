using System;

public class Unit
{
    public string Name { get; }
    private float health;
    public float Health
    {
        get { return health; }
        private set { health = value; }
    }
    private Interval damage;
    private Weapon? weapon;
    private Helm? helm;
    private Shell? shell;
    private Boots? boots;

    public override string ToString()
    {
        return $"{Name}, Здоровье: {Health}, Урон: {Damage}, Защита: {Armor}"; //Переопределяем метод ToString() для удобного вывода объектов в консоль.
    }

    public Unit() : this("Безымянный боец") { }

    public Unit(string name, float initialHealth = 100, int minDamage = 0, int maxDamage = 5)
    {
        Name = name;
        health = initialHealth;
        damage = new Interval(minDamage, maxDamage);
    }

    public Unit(string name, Interval damage)
    {
        Name = name;
        this.damage = damage;
    }

    public float Damage
    {
        get
        {
            return weapon != null ? weapon.GetDamage() + damage.Get() : damage.Get();
        }
    }

    public float Armor
    {
        get
        {
            float totalArmor = 0;
            if (helm != null) totalArmor += helm.ArmorValue;
            if (shell != null) totalArmor += shell.ArmorValue;
            if (boots != null) totalArmor += boots.ArmorValue;
            return (float)Math.Round(totalArmor, 2);
        }
    }

    public float RealHealth()
    {
        return Health * (1f + Armor);
    }

    public bool SetDamage(float value)
    {
        health -= value * (1f - Math.Min(Armor, 1f));
        return health <= 0f;
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;
    }

    public void EquipHelm(Helm newHelm)
    {
        helm = newHelm;
    }

    public void EquipShell(Shell newShell)
    {
        shell = newShell;
    }

    public void EquipBoots(Boots newBoots)
    {
        boots = newBoots;
    }
}

public class Weapon
{
    public string Name { get; }
    public Interval DamageInterval { get; private set; }
    public float Durability { get; } = 1f;

    public Weapon(string name)
    {
        Name = name;
        DamageInterval = new Interval(1, 10);
    }

    public Weapon(string name, Interval damageInterval) : this(name)
    {
        DamageInterval = damageInterval;
    }

    public float GetDamage()
    {
        return DamageInterval.Get();
    }

    public override string ToString()
    {
        return $"{Name}, Диапазон урона: {DamageInterval.Min} - {DamageInterval.Max}";
    }
}

public static class InputHelper
{
    public static float GetFloatInput(string text)
    {
        float result;
        string? input;
        do
        {
            Console.Write(text);
            input = Console.ReadLine()?.Replace('.', ',');
        } while (!float.TryParse(input, out result));
        return result;
    }
}

public struct Interval
{
    private Random random;
    public float Min { get; private set; }
    public float Max { get; private set; }

    public Interval(int minValue, int maxValue)
    {
        random = new Random();

        if (minValue > maxValue)
        {
            Console.WriteLine("Эй, минимум больше максимума! Ща поменяем их местами, не переживай.");
            int temp = minValue;
            minValue = maxValue;
            maxValue = temp;
        }

        if (minValue < 0)
        {
            Console.WriteLine("Ты чего, минимум меньше нуля! Ставим 0, играй честно.");
            minValue = 0;
        }

        if (maxValue < 0)
        {
            Console.WriteLine("Максимум тоже меньше нуля? Да ну! Поднимаем его до 0.");
            maxValue = 0;
        }

        if (minValue == maxValue)
        {
            Console.WriteLine("Ага, границы равны! Поднимем максимум на 10, будет повеселее.");
            maxValue += 10;
        }

        Min = minValue;
        Max = maxValue;
    }

    public float Get()
    {
        return (float)(random.NextDouble() * (Max - Min) + Min);
    }
}

public struct Room
{
    public Unit Unit { get; private set; }
    public Weapon Weapon { get; private set; }

    public Room(Unit unit, Weapon weapon)
    {
        Unit = unit;
        Weapon = weapon;
    }
}

public class Dungeon
{
    private Room[] rooms;

    public Dungeon()
    {
        rooms = new Room[]
        {
            new Room(new Unit("Воин", 100, 5, 15), new Weapon("Меч", new Interval(10, 20))),
            new Room(new Unit("Маг", 80, 3, 10), new Weapon("Посох", new Interval(15, 25))),
            new Room(new Unit("Разбойник", 90, 4, 12), new Weapon("Кинжал", new Interval(8, 18))),
            new Room(new Unit("Лучник", 85, 2, 10), new Weapon("Лук", new Interval(12, 22)))
        };
    }

    public void ShowRooms()
    {
        for (int i = 0; i < rooms.Length; i++)
        {
            var room = rooms[i];
            Console.WriteLine($"Заглянем в комнату номер:{i + 1}... Кто тут у нас? Да это же {room.Unit}!");
            Console.WriteLine($"И вооружен он как положено: {room.Weapon}. Ох, кто-то явно готов к бою!");
            Console.WriteLine("---");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ща будем готовиться к махачу, держитесь, ребята!");
        Console.Write("Как зовут твоего бойца? Не стесняйся, выдавай имя: ");
        string name = Console.ReadLine();
        float health = InputHelper.GetFloatInput("Сколько здоровья у него будет? Вводи число от 10 до 100, не хитри: ");
        float helmArmor = InputHelper.GetFloatInput("Броня у шлема какая? От 0 до 1, только без обмана: ");
        float shellArmor = InputHelper.GetFloatInput("А у кирасы? Тоже от 0 до 1, не халтурь: ");
        float bootsArmor = InputHelper.GetFloatInput("Ну и сапоги, сколько брони дадут? Давай от 0 до 1, и не жадничай: ");

        float minDamage = InputHelper.GetFloatInput("Минимальный урон от оружия какой? Давай от 0 до 20, только без приколов: ");
        float maxDamage = InputHelper.GetFloatInput("А максимальный урон? Тут уже посерьезней, от 20 до 40, ну-ка выдавай: ");

        Unit player = new Unit(name, health, (int)minDamage, (int)maxDamage);
        Weapon weapon = new Weapon("Меч", new Interval((int)minDamage, (int)maxDamage));
        player.EquipWeapon(weapon);

        Helm helm = new Helm("Шлем", helmArmor);
        Shell shell = new Shell("Кираса", shellArmor);
        Boots boots = new Boots("Сапоги", bootsArmor);

        player.EquipHelm(helm);
        player.EquipShell(shell);
        player.EquipBoots(boots);

        Console.WriteLine($"Общий показатель брони: {player.Armor}");
        Console.WriteLine($"Фактическое здоровье: {player.RealHealth()}");

        Dungeon dungeon = new Dungeon();
        Console.WriteLine("\nИнформация о подземелье:");
        dungeon.ShowRooms();
    }
}