using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.ViewModels.SpeakerViewModels;
using Podcast.DAL.DataContext.Entities;
using Podcast.DAL.Repositories.Contracts;
using System.Linq.Expressions;

namespace Podcast.BLL.Services;

public class SpeakerManager : CrudManager<Speaker, SpeakerViewModel, SpeakerCreateViewModel, SpeakerUpdateViewModel>, ISpeakerService
{
    public SpeakerManager(IRepositoryAsync<Speaker> repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public override Task<SpeakerViewModel?> GetAsync(Expression<Func<Speaker, bool>> predicate, Func<IQueryable<Speaker>, IIncludableQueryable<Speaker, object>>? include = null, Func<IQueryable<Speaker>, IOrderedQueryable<Speaker>>? orderBy = null)
    {
        return base.GetAsync(predicate, include, orderBy);
    }
}