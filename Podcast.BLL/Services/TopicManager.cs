using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.Utilities;
using Podcast.BLL.ViewModels.TopicViewModels;
using Podcast.DAL.DataContext.Entities;
using Podcast.DAL.Repositories;
using Podcast.DAL.Repositories.Contracts;

namespace Podcast.BLL.Services;

public class TopicManager : CrudManager<Topic, TopicViewModel, TopicCreateViewModel, TopicUpdateViewModel>, ITopicService
{
    private readonly IMapper _mapper;
    private readonly ITopicRepository _topicRepository;
    public TopicManager(IRepositoryAsync<Topic> repository, IMapper mapper,ITopicRepository topicRepository) : base(repository, mapper)
    {
    _mapper = mapper;
        _topicRepository = topicRepository;
    }

    public async Task<bool> CreateAsync(TopicCreateViewModel topicCreateViewModel, ModelStateDictionary modelState, string folderPath)
    {
        if (!modelState.IsValid) return false;

        if (!topicCreateViewModel.CoverFile.CheckType())
        {
            modelState.AddModelError("Image", "Please enter valid input");
            return false;
        }

        if (!topicCreateViewModel.CoverFile.CheckSize(2))
        {
            modelState.AddModelError("Image", "Please enter valid input");
            return false;
        }

        var topicList = await _topicRepository.GetListAsync();

        foreach (var item in topicList)
        {
            if (item.Name.Equals(topicCreateViewModel.Name))
            {
                modelState.AddModelError("Name", "There are already topic with this name");
                return false;
            }
        }
        string fileName = await topicCreateViewModel.CoverFile.CreateFileAsync(folderPath);
        topicCreateViewModel.CoverUrl = fileName;
        var topic = _mapper.Map<Topic>(topicCreateViewModel);
        await _topicRepository.CreateAsync(topic);
        return true;
    }

    public async Task<TopicUpdateViewModel?> GetTopicForUpdateAsync(int id)
    {
        var topic = await _topicRepository.GetAsync(id);
        if (topic == null) return null;
        var v = _mapper.Map<TopicUpdateViewModel>(topic);
        return v;
    }

    public async Task<bool?> UpdateAsync(TopicUpdateViewModel updateViewModel, ModelStateDictionary modelState, string folderPath)
    {
        if (!modelState.IsValid) return false;
        var existingTopic = await _topicRepository.GetAsync(updateViewModel.Id);
        if (existingTopic == null)
        {
            return null;
        }
        if (updateViewModel.CoverFile != null)
        {
            if (!updateViewModel.CoverFile.CheckType())
            {
                modelState.AddModelError("Image", "Please enter valid input");
                return false;
            }

            if (!updateViewModel.CoverFile.CheckSize(2))
            {
                modelState.AddModelError("Image", "Please enter valid input");
                return false;
            }

            string fileName = await updateViewModel.CoverFile.CreateFileAsync(folderPath);
            updateViewModel.CoverUrl = fileName;
            var oldPath = Path.Combine(folderPath, existingTopic.CoverUrl);
            oldPath.DeleteFile();

        }
        else
        {
            updateViewModel.CoverUrl = existingTopic.CoverUrl;
        }
        var topicList = await _topicRepository.GetListAsync();
        foreach (var item in topicList)
        {
            if (item.Name == updateViewModel.Name)
            {
                modelState.AddModelError("Name", "There are already topic with this name");
                return false;
            }
        }
        _mapper.Map(updateViewModel, existingTopic);
        await _topicRepository.UpdateAsync(existingTopic);
        return true;
    }
 
}