using System;
using System.Linq;
using AOP.Database;

namespace AOP.Services
{
    public class ItemService : IItemService
    {
        Context Context { get; }

        public ItemService(Context context)
        {
            Context = context;
        }


        public ItemEntity Add(ItemEntity entity)
        {
            var isAlreadyInDatabase = Context.Items.Any(i => i.Name == entity.Name);

            if(isAlreadyInDatabase)
                throw new ArgumentException("Item already in databases");

            Context.Items.Add(entity);
            Context.SaveChanges();

            return entity;
        }

        public void Delete(int id)
        {
            var item = Context.Items.FirstOrDefault(i => i.Id == id);

            if(item == null)
                throw new ArgumentException("Item does not exist");
            if(item.IsDeleted)
                throw new ArgumentException("Item already deleted");

            item.IsDeleted = true;
            Context.SaveChanges();
        }
    }
}