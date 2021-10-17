using System.Collections.Generic;
using System;

namespace Wasted.Data
{
public class ItemModel
    {
        public string Item {get;set;}
        public int Amount {get;set;}
        public string Unit {get;set;}
        public string Date {get;set;}
    }
    
public class DishModel : IComparable<DishModel>
    {
        public string Name {get; set;}

        public List<ItemModel> Ingredients {get; set;}

        public int Relevance {get; set;} //easy to make (least ingredients required)

        public int CompareTo(DishModel other)
        {
            return Relevance.CompareTo(other.Relevance);
        }
    }

}   