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
            CreateMap<WordClass, CreateWordClassDto>().ReverseMap();
            CreateMap<WordClass, GetWordClassDto>().ReverseMap();
            CreateMap<WordClass, GetWordClassDetailsDto>().ReverseMap();
            CreateMap<WordClass, UpdateWordClassDto>().ReverseMap();

            //Word:
            CreateMap<Word, GetWordDto>().ReverseMap();
            CreateMap<Word, GetWordDetailsDto>().ReverseMap(); //vurderer å slette denne Dto-klassen
            CreateMap<Word, CreateWordDto>().ReverseMap();
            CreateMap<Word, UpdateWordDto>().ReverseMap();

            //WordProject:
            CreateMap<WordProject, GetWordProjectDto>().ReverseMap();
            CreateMap<WordProject, CreateWordProjectDto>().ReverseMap();
            CreateMap<WordProject, UpdateWordDto>().ReverseMap();

            //Project:
            CreateMap<Project, GetProjectDto>().ReverseMap();
            CreateMap<Project, CreateProjectDto>().ReverseMap();
            CreateMap<Project, UpdateProjectDto>().ReverseMap();






        }
    }
}
