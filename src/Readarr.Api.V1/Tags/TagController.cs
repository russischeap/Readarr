using System.Collections.Generic;
using NzbDrone.Core.Datastore.Events;
using NzbDrone.Core.Messaging.Events;
using NzbDrone.Core.Tags;
using NzbDrone.SignalR;
using Readarr.Http;

namespace Readarr.Api.V1.Tags
{
    [V1ApiController]
    public class TagController : ReadarrRestControllerWithSignalR<TagResource, Tag>, IHandle<TagsUpdatedEvent>
    {
        private readonly ITagService _tagService;

        public TagController(IBroadcastSignalRMessage signalRBroadcaster,
                         ITagService tagService)
            : base(signalRBroadcaster)
        {
            _tagService = tagService;

            GetResourceById = GetTag;
            GetResourceAll = GetAll;
            CreateResource = Create;
            UpdateResource = Update;
            DeleteResource = DeleteTag;
        }

        private TagResource GetTag(int id)
        {
            return _tagService.GetTag(id).ToResource();
        }

        private List<TagResource> GetAll()
        {
            return _tagService.All().ToResource();
        }

        private int Create(TagResource resource)
        {
            return _tagService.Add(resource.ToModel()).Id;
        }

        private void Update(TagResource resource)
        {
            _tagService.Update(resource.ToModel());
        }

        private void DeleteTag(int id)
        {
            _tagService.Delete(id);
        }

        public void Handle(TagsUpdatedEvent message)
        {
            BroadcastResourceChange(ModelAction.Sync);
        }
    }
}
