using Microsoft.AspNetCore.Mvc;
using NzbDrone.Core.Configuration;
using Readarr.Http;

namespace Readarr.Api.V1.Config
{
    [V1ApiController("config/downloadclient")]
    public class DownloadClientConfigController : ReadarrConfigController<DownloadClientConfigResource>
    {
        public DownloadClientConfigController(IConfigService configService)
            : base(configService)
        {
        }

        protected override DownloadClientConfigResource ToResource(IConfigService model)
        {
            return DownloadClientConfigResourceMapper.ToResource(model);
        }
    }
}
