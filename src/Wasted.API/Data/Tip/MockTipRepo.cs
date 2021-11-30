using Wasted.API.Models;
using System.Collections.Generic;

namespace Wasted.API.Data
{
    public class MockTipRepo : ITipRepo
    {
        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
        public IEnumerable<Tip> GetTipList()
        {
            List<Tip> tips = new List<Tip>
            {
                new Tip { TipId = 1, TipName = "Shop Smart", Name = "To avoid buying more food than you need, make frequent trips to the grocery store every few days rather than doing a bulk shopping trip once a week.", TipLikes = 4, TipDislikes = 0, Link = "https://en.wikipedia.org/wiki/Smart_shop", AdminApproved = true},
                new Tip { TipId = 2, TipName = "Store Food Correctly", Name = "Separating foods that produce more ethylene gas from those that don’t is another great way to reduce food spoilage. Ethylene promotes ripening in foods and could lead to spoilage.", TipLikes = 4, TipDislikes = 0, Link = "https://www.betterhealth.vic.gov.au/health/healthyliving/food-safety-and-storage", AdminApproved = true},
                new Tip { TipId = 3, TipName = "Learn to Preserve", Name = "Pickling, drying, canning, fermenting, freezing and curing are all methods you can use to make food last longer, thus reducing waste.", TipLikes = 1, TipDislikes = 0, Link = "https://www.masterclass.com/articles/a-guide-to-home-food-preservation-how-to-pickle-can-ferment-dry-and-preserve-at-home", AdminApproved = true}
            };
            return tips;
        }

        public Tip GetTipById(int id)
        {
            return new Tip { TipId = 2, TipName = "Store Food Correctly", Name = "Separating foods that produce more ethylene gas from those that don’t is another great way to reduce food spoilage. Ethylene promotes ripening in foods and could lead to spoilage.", TipLikes = 4, TipDislikes = 0, Link = "https://www.betterhealth.vic.gov.au/health/healthyliving/food-safety-and-storage", AdminApproved = true};
        }

        public void CreateNewTip(Tip tip)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateTip(Tip tip)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTip(Tip tip)
        {
            throw new System.NotImplementedException();
        }
    }
}
