using System.Collections.Generic;
using System;

namespace Wasted.Data
{
public class RecipeModel
    {
        public string Item {get;set;}
        public int Left {get;set;}
        public string Unit {get;set;}
        public string Date {get;set;}
    }
    
public class DishModel
    {
        public string Name {get; set;}

        public List<RecipeModel> Ingredients {get; set;}
    }
}   