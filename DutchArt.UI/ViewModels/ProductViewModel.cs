using DutchArt.Data.Entities;
using DutchArt.Models;
using System.Collections.Generic;

namespace DutchArt.ViewModels
{
    public class ProductViewModel : Product
    {
        public List<EntityLink> Links { get; set; }
    }
}