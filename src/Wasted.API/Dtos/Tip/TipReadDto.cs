using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted.API.Dtos
{
    public class TipReadDto
    {
        public int TipId { get; set; }
        public string TipName { get; set; }
        public string Name { get; set; }
        public int TipLikes { get; set; }
        public int TipDislikes { get; set; }
        public string Link { get; set; }
        public Boolean AdminApproved {get; set;}
    }
}