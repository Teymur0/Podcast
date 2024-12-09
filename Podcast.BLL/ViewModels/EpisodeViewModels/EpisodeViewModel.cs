using Microsoft.AspNetCore.Http;
using Podcast.BLL.ViewModels.SpeakerViewModels;
using Podcast.BLL.ViewModels.TopicViewModels;
using System.Web.Mvc;

namespace Podcast.BLL.ViewModels.EpisodeViewModels
{
    public class EpisodeViewModel : IViewModel
    {
        public int Id {  get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CoverUrl { get; set; }
        public string? MusicUrl { get; set; }
        public int ViewCount { get; set; }
        public int DownloadCount { get; set; }
        public int LikeCount { get; set; }
        public int DurationInMinute { get; set; }
        public SpeakerViewModel? Speaker { get; set; }
        public TopicViewModel? Topic { get; set; }
    }

    public class EpisodeCreateViewModel : IViewModel
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required IFormFile CoverFile { get; set; }
        public string? CoverUrl { get; set; }
        public required IFormFile MusicFile { get; set; }
        public string? MusicUrl { get; set; }
        public int ViewCount { get; set; }
        public int DownloadCount { get; set; }
        public int LikeCount { get; set; }
        public int DurationInMinute { get; set; }
        public int SpeakerId {  get; set; }
        public List<SelectListItem>? Speakers { get; set; }
        public int TopicId {  get; set; }
        public List<SelectListItem>? Topics {  get; set; }
    }

    public class EpisodeUpdateViewModel : IViewModel
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public IFormFile? CoverFile { get; set; }
        public string? CoverUrl { get; set; }
        public IFormFile? MusicFile { get; set; }
        public string? MusicUrl { get; set; }
        public int ViewCount { get; set; }
        public int DownloadCount { get; set; }
        public int LikeCount { get; set; }
        public int DurationInMinute { get; set; }
        public int SpeakerId { get; set; }
        public List<SelectListItem>? Speakers { get; set; }
        public int TopicId { get; set; }
        public List<SelectListItem>? Topics { get; set; }
    }
}
