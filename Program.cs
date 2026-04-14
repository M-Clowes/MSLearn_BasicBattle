Character hero = new("Hero");
Character monster = new("Monster");

while (true)
{
    monster.Defend(hero.Attack());
    if (!monster.Alive)
        break;

    hero.Defend(monster.Attack());
    if (!hero.Alive)
        break;
}

Console.WriteLine(hero.Health > monster.Health? "Hero wins!": "Monster wins!");