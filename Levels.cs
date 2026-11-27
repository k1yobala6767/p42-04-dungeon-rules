// Данные уровня: карта, где стоит игрок, где монстры, где лежат предметы, что продаёт торговец.
// Как всё должно быть расставлено — смотрите рисунок карты в README.

public static class Levels
{
    // Карта: # стена, . пол, $ торговец, > выход.
    // Строка номер y сверху вниз, символ номер x слева направо (счёт с 0).
    public static readonly string[] MapRows =
    {
        "##########",   // y = 0
        "#..#.....#",   // y = 1
        "#..#.##.##",   // y = 2
        "#.....#..#",   // y = 3
        "#.##.##.##",   // y = 4
        "#.#..#...#",   // y = 5
        "#.#.##.#.#",   // y = 6
        "#...#..#.#",   // y = 7
        "#.#...$#>#",   // y = 8
        "##########",   // y = 9
    };

    // Клетка, на которой игрок начинает игру.
    public const int StartX = 1;
    public const int StartY = 1;

    public static Monster[] CreateMonsters()
    {
        return new Monster[]
        {
            Catalog.Rat(3, 3),
            Catalog.Goblin(6, 1),
            Catalog.Skeleton(8, 7),
        };
    }

    public static FloorItem[] CreateLoot()
    {
        return new FloorItem[]
        {
            new FloorItem(Catalog.SmallPotion(), 2, 2),
            new FloorItem(Catalog.SmallPotion(), 5, 7),
            new FloorItem(Catalog.Key(), 8, 1),
        };
    }

    // Товары торговца по порядку: товар номер 1, товар номер 2...
    public static Item[] CreateGoods()
    {
        return new Item[]
        {
            Catalog.SmallPotion(),
            Catalog.Sword(),
        };
    }
}
