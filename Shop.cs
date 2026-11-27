// Торговец: список товаров и покупка. Товары не заканчиваются.

public class Shop
{
    private readonly Item[] _goods;

    public Shop(Item[] goods)
    {
        _goods = goods;
    }

    public int Count => _goods.Length;

    // Товар по индексу (индексы с 0). Если такого товара нет — null.
    public Item Get(int index)
    {
        if (index < 0 || index >= _goods.Length)
            return null;
        return _goods[index];
    }

    // Игрок покупает товар с номером number (номера с 1, как в списке товаров).
    // Возвращает сообщение для игрока.
    // Покупка не удаётся, если такого товара нет, в сумке нет места или не хватает золота.
    // Если покупка не удалась, золото игрока не меняется.
    public string Buy(Player player, int number)
    {
        Item item = Get(number - 1);
        if (item == null)
            return "У торговца нет товара с номером " + number + ".";
        if (player.Bag.IsFull)
            return "В сумке нет места.";
        if (!player.SpendGold(item.Price))
            return "Не хватает золота: нужно " + item.Price + ", у вас " + player.Gold + ".";

        player.Bag.Add(item);
        return "Вы купили: " + item.Name + " за " + item.Price + " зол.";
    }
}
