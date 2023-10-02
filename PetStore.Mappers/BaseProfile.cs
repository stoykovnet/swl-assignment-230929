using AutoMapper;
using PetStore.API.Swagger.Controllers.Generated;
using PetStore.DataAccessLayer.Models;
using System.Net;

namespace PetStore.Mappers;

public class BaseProfile : Profile
{
    public BaseProfile()
    {
        CreateMap<Pet, PetModel>();
        CreateMap<PetModel, Pet>();
        CreateMap<Category, CategoryModel>();
        CreateMap<CategoryModel, Category>();
        CreateMap<Tag, TagModel>();
        CreateMap<TagModel, Tag>();
    }
}