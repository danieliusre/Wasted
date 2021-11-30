using System;

namespace Wasted.Data
{
    public class Tip
    {
        public int TipId {get; set;}
        public string TipName { get; set; }
        public string Name { get; set; }
        public int TipLikes { get; set; }
        public int TipDislikes { get; set; }
        public string Link { get; set; }
        public Boolean AdminApproved {get; set;}
    }
}
