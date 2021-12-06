using Wasted.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Wasted.API.Data
{
    public class SqlFridgeRepo : IFridgeRepo
    {
        private readonly WastedContext _context;

        public SqlFridgeRepo(WastedContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public IEnumerable<FridgeItem> GetFridgeItemList()
        {
            return _context.FridgeItems.ToList();
        }
        public FridgeItem GetFridgeItem(int userId, int productId)
        {
             return _context.FridgeItems.FirstOrDefault(p => p.ProductId == productId && p.UserId == userId);
        }
        public void CreateFridgeItem(FridgeItem fridgeItem)
        {
            if (fridgeItem == null){
                throw new ArgumentException(nameof(fridgeItem));
            }

            _context.FridgeItems.Add(fridgeItem);
        }
        public void DeleteFridgeItem(FridgeItem fridgeItem)
        {
            if (fridgeItem == null){
                throw new ArgumentException(nameof(fridgeItem));
            }

            _context.FridgeItems.Remove(fridgeItem);
        }
    }
}
