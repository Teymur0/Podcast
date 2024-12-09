using Podcast.BLL.ViewModels.EpisodeViewModels;
using Podcast.DAL.DataContext.Entities;

namespace Podcast.BLL.Services.Contracts;

public interface IEpisodeService : ICrudService<Episode, EpisodeViewModel, EpisodeCreateViewModel, EpisodeUpdateViewModel>
{

}
