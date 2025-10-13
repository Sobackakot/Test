public interface IItemFactory
{
    // Создает найденный предмет (например, арбалет или топор), низкое качество более вероятно (80%).
    Item CreateFound(ItemType type);

    // Создает самодельный предмет (например, лук), высокое качество более вероятно (80%).
    Item CreateSelfMade(ItemType type);
}
 