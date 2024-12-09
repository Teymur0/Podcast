using Podcast.BLL.ViewModels.SpeakerViewModels;
using Podcast.DAL.DataContext.Entities;

namespace Podcast.BLL.Services.Contracts;

public interface ISpeakerService : ICrudService<Speaker, SpeakerViewModel, SpeakerCreateViewModel, SpeakerUpdateViewModel>
{

}