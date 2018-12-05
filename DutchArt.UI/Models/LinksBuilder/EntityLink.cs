using System;

namespace DutchArt.Models
{
    public class EntityLink
    {
        public string Method { get; set; }
        public string Rel { get; set; }
        public Uri Href { get; set; }
    }
}