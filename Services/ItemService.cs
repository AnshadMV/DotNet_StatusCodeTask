public class ItemService
{
    private readonly List<Item> _items = new();

    public List<Item> GetAll() => _items;

    public Item GetById(int id) =>
        _items.FirstOrDefault(x => x.Id == id);

    public Item Add(Item item)
    {
        item.Id = _items.Count + 1;
        _items.Add(item);
        return item;
    }

    public bool Update(int id, Item updatedItem)
    {
        var existing = _items.FirstOrDefault(x => x.Id == id);
        if (existing == null) return false;

        existing.Title = updatedItem.Title;
        existing.Description = updatedItem.Description;
        return true;
    }
}
