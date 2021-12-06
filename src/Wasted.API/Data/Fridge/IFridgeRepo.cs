using Wasted.API.Models;
using System.Collections.Generic;

namespace Wasted.API.Data
{
    public interface IFridgeRepo
    {
        bool SaveChanges();
        IEnumerable<FridgeItem> GetFridgeItemList();
        FridgeItem GetFridgeItem(int userId, int productId);
        void CreateFridgeItem(FridgeItem fridgeItem);
        void DeleteFridgeItem(FridgeItem fridgeItem);
    }
}
