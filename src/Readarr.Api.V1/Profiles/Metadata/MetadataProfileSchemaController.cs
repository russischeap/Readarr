using NzbDrone.Core.Profiles.Metadata;
using Readarr.Http;

namespace Readarr.Api.V1.Profiles.Metadata
{
    [V1ApiController("metadataprofile/schema")]
    public class MetadataProfileSchemaController : ReadarrRestController<MetadataProfileResource>
    {
        public MetadataProfileSchemaController()
        {
            GetResourceSingle = GetAll;
        }

        private MetadataProfileResource GetAll()
        {
            var profile = new MetadataProfile
            {
                AllowedLanguages = "eng, en-US, en-GB"
            };

            return profile.ToResource();
        }
    }
}
