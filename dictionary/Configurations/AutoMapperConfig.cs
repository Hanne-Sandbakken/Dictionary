using AutoMapper;
using dictionary.Data;
using dictionary.Dto.Category;
using dictionary.Dto.Project;
using dictionary.Dto.Word;
using dictionary.Dto.WordProjects;

namespace dictionary.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {

            //Category:
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDetailsDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            //Word:
            CreateMap<Word, GetWordDto>().ReverseMap();
            CreateMap<Word, GetWordDetailsDto>().ReverseMap();
            CreateMap<Word, CreateWordDto>().ReverseMap();
            CreateMap<Word, UpdateWordDto>().ReverseMap();

            //WordProject:
            CreateMap<WordProject, GetWordProjectDto>().ReverseMap();
            CreateMap<WordProject, GetWordProjectDetailsDto>().ReverseMap();
            CreateMap<WordProject, CreateWordProjectDto>().ReverseMap();
            CreateMap<WordProject, UpdateWordDto>().ReverseMap();

            //Project:
            CreateMap<Project, GetProjectDto>().ReverseMap();
            CreateMap<Project, GetProjectDetailsDto>().ReverseMap();
            CreateMap<Project, CreateProjectDto>().ReverseMap();
            CreateMap<Project, UpdateProjectDto>().ReverseMap();






        }
    }
}
