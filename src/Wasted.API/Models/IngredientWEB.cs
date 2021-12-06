using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wasted.API.Models
{
    public class IngredientWEB
    {
        public string Item {get;set;}
        public int Amount {get;set;}
        public string Unit {get;set;}
        public string Date {get;set;}
    }

}
