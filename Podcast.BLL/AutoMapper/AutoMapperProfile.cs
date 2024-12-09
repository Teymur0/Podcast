using AutoMapper;
using Podcast.BLL.ViewModels.EpisodeViewModels;
using Podcast.BLL.ViewModels.SpeakerViewModels;
using Podcast.BLL.ViewModels.TopicViewModels;
using Podcast.DAL.DataContext.Entities;

namespace Podcast.BLL.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Speaker, SpeakerViewModel>()
            .ForMember(dest => dest.Professions, 
            opt => opt.MapFrom(src => src.SpeakerProfessions!.Select(sp => sp.Profession)))
            .ReverseMap();

        CreateMap<Speaker, SpeakerCreateViewModel>().ReverseMap();
        CreateMap<Speaker, SpeakerUpdateViewModel>().ReverseMap();


        CreateMap<Profession, ProfessionViewModel>().ReverseMap();

        CreateMap<TopicViewModel, Topic>().ReverseMap();
        CreateMap<TopicCreateViewModel, Topic>().ReverseMap();
        CreateMap<TopicUpdateViewModel, Topic>().ReverseMap();

        CreateMap<EpisodeViewModel, Episode>().ReverseMap();
        CreateMap<EpisodeCreateViewModel, Episode>().ReverseMap();
        CreateMap<EpisodeUpdateViewModel, Episode>().ReverseMap();
    }
}
