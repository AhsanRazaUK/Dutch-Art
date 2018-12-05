using System;

namespace DutchArt.Data.Entities
{
    public class Art
    {
        public string ArtId { get; set; }
        public string ArtDescription { get; set; }
        public string ArtDating { get; set; }
        public string Artist { get; set; }
        public DateTime ArtistBirthDate { get; set; }
        public DateTime ArtistDeathDate { get; set; }
        public string ArtistNationality { get; set; }
    }
}