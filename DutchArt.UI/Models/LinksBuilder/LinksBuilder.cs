using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DutchArt.Models
{
    public enum HttpMethods
    {
        Get = 1,
        Post = 2,
        Put = 3,
        Delete = 4,
        Patch = 5
    }

    public class RouteMethods
    {
        public HttpMethods HttpMethod { get; set; }
        public string RouteMethodName { get; set; }
    }
    public class LinksBuilder : ILinksBuilder
    {
        public PageLinksUri CreatePageLinks(IUrlHelper urlHelper, string routeName, object routeValues, int page, int pageSize, long totalRecordCount)
        {
            var pageCount = totalRecordCount > 0
                ? (int)Math.Ceiling(totalRecordCount / (double)pageSize)
                : 0;

            return new PageLinksUri()
            {
                First = new Uri(urlHelper.Link(routeName, new { page = 1, pageSize })),

                Last = new Uri(urlHelper.Link(routeName, new { page = pageCount, pageSize })),

                Previous = page > 1 ? new Uri(urlHelper.Link(routeName, new { page = page - 1, pageSize })) : null,

                Next = page < pageCount ? new Uri(urlHelper.Link(routeName, new { page = page + 1, pageSize })) : null

            };
        }

        public EntityLink CreateEntityLink(IUrlHelper urlHelper, string routeName, int Id, HttpMethods Method = HttpMethods.Get)
        {
            return
                  new EntityLink()
                  {
                      Method = Method.ToString(),
                      Rel = "self",
                      Href = new Uri(urlHelper.Link(routeName, new { id = Id }))
                  };
        }

        public List<EntityLink> CreateEntityLinks(IUrlHelper urlHelper, int Id, List<RouteMethods> IncludeMethods)
        {
            var Links = new List<EntityLink>();

            foreach (var method in IncludeMethods)
            {
                Links.Add(CreateEntityLink(urlHelper, method.RouteMethodName, Id, method.HttpMethod));
            }

            return Links;
        }
    }
}
