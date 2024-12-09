using AutoMapper;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.ViewModels.EpisodeViewModels;
using Podcast.DAL.DataContext.Entities;
using Podcast.DAL.Repositories.Contracts;

namespace Podcast.BLL.Services;

public class EpisodeManager : CrudManager<Episode, EpisodeViewModel, EpisodeCreateViewModel, EpisodeUpdateViewModel>, IEpisodeService
{
    public EpisodeManager(IRepositoryAsync<Episode> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
