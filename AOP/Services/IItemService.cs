using AOP.Database;

namespace AOP.Services
{
    public interface IItemService
    {
        ItemEntity Add(ItemEntity entity);
        void Delete(int id);
    }
}