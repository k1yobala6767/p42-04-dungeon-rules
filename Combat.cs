// Бой: кто кого бьёт и сколько урона наносит.

public static class Combat
{
    public const int MinDamage = 1;             // даже самый слабый удар снимает 1 HP

    // Урон = атака минус броня, но не меньше MinDamage.
    public static int Damage(int attack, int armor)
    {
        int damage = attack - armor;
        if (damage < MinDamage)
            damage = MinDamage;
        return damage;
    }

    // Игрок бьёт монстра. Возвращает сообщение для игрока.
    // Золото за монстра выдаётся один раз — когда монстр убит.
    public static string PlayerAttacks(Player player, Monster monster)
    {
        int damage = Damage(player.Attack, monster.Armor);
        monster.TakeDamage(damage);
        if (!monster.IsAlive)
    {
    player.AddGold(monster.Reward);
    return "Вы убили: " + monster.Name + ". Награда: " + monster.Reward + " зол.";
    }

        return "Вы ударили: " + monster.Name + " (-" + damage + "), у него осталось " + monster.Health + " HP.";
    }

    // Монстр бьёт игрока. Брони у игрока нет. Возвращает сообщение для игрока.
    public static string MonsterAttacks(Monster monster, Player player)
    {
        int damage = Damage(monster.Attack, 0);
        player.TakeDamage(damage);
        return monster.Name + " бьёт вас (-" + damage + ").";
    }
}
