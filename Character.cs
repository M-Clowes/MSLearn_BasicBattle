class Character
{
    public string Name { get; }
    public bool Alive { get; private set; } = true;
    public int Health { get; private set; } = 10;
    public int Strength { get; private set; } = 10;
    private readonly Random _atkDamage = new();

    public Character(string name, int? weapon = null, int? armour = null)
    {
        this.Name = name;
        this.Strength = weapon ?? this.Strength;
        this.Health += armour ?? 0;
    }

    // +1 offset to complete range
    public int Attack() { return _atkDamage.Next(1, this.Strength + 1); }

    public void Defend(int damage)
    {
        Console.Write(
            $"{this.Name} was damaged and lost " + Math.Min(damage, this.Health) +
            $" health. "
        );
        this.Health -= damage;

        Console.WriteLine(
            $"{this.Name} now has " + (this.Health > 0? this.Health: 0) + " health."
        );

        if (this.Health <= 0)
            this.Alive = false;
    }

    public void EquipWeapon(int damage) { this.Strength = damage; }
    public void EquipArmour(int defence) { this.Health += defence; }
}