using AutoMapper;
using dictionary.Data;
using dictionary.Dto.Category;
using dictionary.Dto.Word;

namespace dictionary.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDetailsDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Word, GetWordDto>().ReverseMap();
           
        }
    }
}
