using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;
using Grocery.Core.Data; // Ensure this is present and correct
using Microsoft.EntityFrameworkCore;

namespace Grocery.Core.Data.Repositories
{
    public class GroceryListItemsRepository : IGroceryListItemsRepository
    {
        private readonly GroceryAppDb _db;

        public GroceryListItemsRepository(GroceryAppDb db)
        {
            _db = db;
        }

        public List<GroceryListItem> GetAll()
        {
            return _db.GroceryListItems
                .Include(g => g.Product)
                .ToList();
        }

        public List<GroceryListItem> GetAllOnGroceryListId(int id)
        {
            return _db.GroceryListItems
                .Include(g => g.Product)
                .Where(g => g.GroceryListId == id)
                .ToList();
        }

        public GroceryListItem Add(GroceryListItem item)
        {
            _db.GroceryListItems.Add(item);
            _db.SaveChanges();
            return Get(item.Id)!;
        }

        public GroceryListItem? Delete(GroceryListItem item)
        {
            var entity = _db.GroceryListItems.Find(item.Id);
            if (entity == null) return null;
            _db.GroceryListItems.Remove(entity);
            _db.SaveChanges();
            return entity;
        }

        public GroceryListItem? Get(int id)
        {
            return _db.GroceryListItems
                .Include(g => g.Product)
                .FirstOrDefault(g => g.Id == id);
        }

        public GroceryListItem? Update(GroceryListItem item)
        {
            var entity = _db.GroceryListItems.Find(item.Id);
            if (entity == null) return null;
            _db.Entry(entity).CurrentValues.SetValues(item);
            _db.SaveChanges();
            return Get(item.Id);
        }
    }
}
