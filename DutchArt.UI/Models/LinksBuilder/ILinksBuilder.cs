using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DutchArt.Models
{
    public interface ILinksBuilder
    {
        EntityLink CreateEntityLink(IUrlHelper urlHelper, string routeName, int Id, HttpMethods Method = HttpMethods.Get);
        List<EntityLink> CreateEntityLinks(IUrlHelper urlHelper, int Id, List<RouteMethods> IncludeMethods);
        PageLinksUri CreatePageLinks(IUrlHelper urlHelper, string routeName, object routeValues, int page, int pageSize, long totalRecordCount);
    }
}