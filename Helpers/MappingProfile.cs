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
                .ForPath(dest => dest.AppUserId,
                opt => opt.MapFrom(
                    src => src.AppUserId))
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
                .ForPath(dest => dest.AppUserId,
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
