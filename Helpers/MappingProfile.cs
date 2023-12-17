using AutoMapper;
using IdentityPractice.Models;
using ToDoApp.Interface;
using ToDoApp.ViewModels;

namespace IdentityPractice.Helpers
{
    public class MappingProfile : Profile
    {
        
        public MappingProfile()
        {
            
            CreateMap<CreateListViewModel, ToDo>()
                .ForMember(dest => dest.Id,
                opt => opt.MapFrom(
                    src => src.Id))
                .ForMember(dest => dest.Title,
                 opt => opt.MapFrom(
                    src => src.Title))
                .ForMember(dest => dest.Description,
                opt => opt.MapFrom(
                    src => src.Description))
                .ForMember(dest => dest.Deadline,
                opt => opt.MapFrom(
                    src => src.Deadline))
                .ForMember(dest => dest.ImageUrl,
                opt => opt.MapFrom(
                    src => src.ImageUrl));

            CreateMap<UpdateListViewModel, ToDo>()
                .ForMember(dest => dest.Id,
                opt => opt.MapFrom(
                    src => src.Id))
                .ForMember(dest => dest.Title,
                 opt => opt.MapFrom(
                    src => src.Title))
                .ForMember(dest => dest.Description,
                opt => opt.MapFrom(
                    src => src.Description))
                .ForMember(dest => dest.Deadline,
                opt => opt.MapFrom(
                    src => src.Deadline))
                .ForMember(dest => dest.ImageUrl,
                opt => opt.MapFrom(
                    src => src.ImageUrl));



        }
        
    }
}
