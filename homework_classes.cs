using System;

public class Unit
{
    public string Name { get; }
    private float health;
    public float Health => health;
    private float baseDamage = 5f;
    private Weapon weapon;
    private Helm helm;
    private Shell shell;
    private Boots boots;

    public Unit() : this("Безымянный воин") { }

    public Unit(string name)
    {
        Name = name;
    }

    public float Damage 
    {
        get
        {
            return weapon != null ? weapon.GetDamage() + baseDamage : baseDamage;
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
        health -= value * (1 - Armor);
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
    public float MinDamage { get; private set; }
    public float MaxDamage { get; private set; }

    public Weapon(string name)
    {
        Name = name;
    }

    public Weapon(string name, float minDamage, float maxDamage) : this(name)
    {
        SetDamageParams(minDamage, maxDamage);
    }

    public void SetDamageParams(float minDamage, float maxDamage)
    {
        if (minDamage > maxDamage)
        {
            Console.WriteLine($"Эй, с оружием {Name} что-то не так! Меняю местами урон");
            float temp = minDamage;
            minDamage = maxDamage;
            maxDamage = temp;
        }
        if (minDamage < 1f)
        {
            Console.WriteLine("Форсируем минимальный урон до 1, не хочу, чтобы было меньше");
            minDamage = 1f;
        }
        if (maxDamage <= 1f)
        {
            maxDamage = 10f;
        }

        MinDamage = minDamage;
        MaxDamage = maxDamage;
    }

    public float GetDamage()
    {
        return (MinDamage + MaxDamage) / 2f;
    }
}

public class Helm
{
    public string Name { get; } = "Шлем";
    private float armorValue;
    public float ArmorValue
    {
        get => armorValue;
        set
        {
            if (value < 0f) value = 0f;
            if (value > 1f) value = 1f;
            armorValue = value;
        }
    }
}

public class Shell
{
    public string Name { get; } = "Кираса";
    private float armorValue;
    public float ArmorValue
    {
        get => armorValue;
        set
        {
            if (value < 0f) value = 0f;
            if (value > 1f) value = 1f;
            armorValue = value;
        }
    }
}

public class Boots
{
    public string Name { get; } = "Сапоги";
    private float armorValue;
    public float ArmorValue
    {
        get => armorValue;
        set
        {
            if (value < 0f) value = 0f;
            if (value > 1f) value = 1f;
            armorValue = value;
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
        Console.Write("Сколько здоровья у него будет? Вводи число от 10 до 100, не хитри: ");
        float health = float.Parse(Console.ReadLine());
        Console.Write("Броня у шлема какая? От 0 до 1, только без обмана: ");
        float helmArmor = float.Parse(Console.ReadLine());
        Console.Write("А у кирасы? Тоже от 0 до 1, не халтурь: ");
        float shellArmor = float.Parse(Console.ReadLine());
        Console.Write("Ну и сапоги, сколько брони дадут? Давай от 0 до 1, и не жадничай: ");
        float bootsArmor = float.Parse(Console.ReadLine());
        Console.Write("Минимальный урон от оружия какой? Давай от 0 до 20, только без приколов: ");
        float minDamage = float.Parse(Console.ReadLine());
        Console.Write("А максимальный урон? Тут уже посерьезней, от 20 до 40, ну-ка выдавай: ");
        float maxDamage = float.Parse(Console.ReadLine());

        Unit player = new Unit(name);
        player.SetDamage(-health); // Устанавливаем здоровье игрока
        Weapon weapon = new Weapon("Меч", minDamage, maxDamage);
        player.EquipWeapon(weapon);

        Helm helm = new Helm { ArmorValue = helmArmor };
        Shell shell = new Shell { ArmorValue = shellArmor };
        Boots boots = new Boots { ArmorValue = bootsArmor };

        player.EquipHelm(helm);
        player.EquipShell(shell);
        player.EquipBoots(boots);

        Console.WriteLine($"Общий показатель брони: {player.Armor}");
        Console.WriteLine($"Фактическое здоровье: {player.RealHealth()}");
    }
}
