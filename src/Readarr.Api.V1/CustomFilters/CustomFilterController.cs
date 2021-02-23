using System.Collections.Generic;
using NzbDrone.Core.CustomFilters;
using Readarr.Http;

namespace Readarr.Api.V1.CustomFilters
{
    [V1ApiController]
    public class CustomFilterController : ReadarrRestController<CustomFilterResource>
    {
        private readonly ICustomFilterService _customFilterService;

        public CustomFilterController(ICustomFilterService customFilterService)
        {
            _customFilterService = customFilterService;

            GetResourceById = GetCustomFilter;
            GetResourceAll = GetCustomFilters;
            CreateResource = AddCustomFilter;
            UpdateResource = UpdateCustomFilter;
            DeleteResource = DeleteCustomResource;
        }

        private CustomFilterResource GetCustomFilter(int id)
        {
            return _customFilterService.Get(id).ToResource();
        }

        private List<CustomFilterResource> GetCustomFilters()
        {
            return _customFilterService.All().ToResource();
        }

        private int AddCustomFilter(CustomFilterResource resource)
        {
            var customFilter = _customFilterService.Add(resource.ToModel());

            return customFilter.Id;
        }

        private void UpdateCustomFilter(CustomFilterResource resource)
        {
            _customFilterService.Update(resource.ToModel());
        }

        private void DeleteCustomResource(int id)
        {
            _customFilterService.Delete(id);
        }
    }
}
