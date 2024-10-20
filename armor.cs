using System;

public class Armor
{
    public string Name { get; }

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

    public Armor(string name, float armorValue = 0)
    {
        Name = name;
        ArmorValue = armorValue;
    }
}

public class Helm : Armor
{
    public Helm(string name = "Шлем", float armorValue = 0) : base(name, armorValue) { }
}

public class Shell : Armor
{
    public Shell(string name = "Кираса", float armorValue = 0) : base(name, armorValue) { }
}

public class Boots : Armor
{
    public Boots(string name = "Сапоги", float armorValue = 0) : base(name, armorValue) { }
}
