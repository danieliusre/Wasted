using Wasted.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Wasted.API.Data
{
    public class SqlTipRepo : ITipRepo
    {
        private readonly WastedContext _context;

        public SqlTipRepo(WastedContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public IEnumerable<Tip> GetTipList()
        {
            return _context.Tips.ToList();
        }

        public Tip GetTipById(int id)
        {
            return _context.Tips.FirstOrDefault(p => p.TipId == id);
        }

        public void CreateNewTip(Tip tip)
        {
            if (tip == null){
                throw new ArgumentException(nameof(tip));
            }

            _context.Tips.Add(tip);
        }

        public void UpdateTip(Tip tip)
        {
            //Nothing
        }

        public void DeleteTip(Tip tip)
        {
            if (tip == null){
                throw new ArgumentException(nameof(tip));
            }

            _context.Tips.Remove(tip);
        }
    }
}
