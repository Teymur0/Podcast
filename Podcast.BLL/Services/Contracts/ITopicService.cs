using Microsoft.AspNetCore.Mvc.ModelBinding;
using Podcast.BLL.ViewModels.TopicViewModels;
using Podcast.DAL.DataContext.Entities;

namespace Podcast.BLL.Services.Contracts;

public interface ITopicService : ICrudService<Topic, TopicViewModel, TopicCreateViewModel, TopicUpdateViewModel>
{
    Task<bool> CreateAsync(TopicCreateViewModel topicCreateViewModel,ModelStateDictionary modelState,string folderPath);
    Task<bool?> UpdateAsync(TopicUpdateViewModel updateViewModel, ModelStateDictionary modelState, string folderPath);
    Task<TopicUpdateViewModel?> GetTopicForUpdateAsync(int id);

}