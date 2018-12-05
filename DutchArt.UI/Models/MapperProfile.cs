using AutoMapper;
using DutchArt.Data.Entities;
using DutchArt.ViewModels;

namespace DutchArt.Models
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
