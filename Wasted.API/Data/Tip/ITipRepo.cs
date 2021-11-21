using Wasted.API.Models;
using System.Collections.Generic;

namespace Wasted.API.Data
{
    public interface ITipRepo
    {
        bool SaveChanges();
        IEnumerable<Tip> GetTipList();
        Tip GetTipById(int id);
        void CreateNewTip(Tip tip);
        void UpdateTip(Tip tip);
        void DeleteTip(Tip tip);
    }
}