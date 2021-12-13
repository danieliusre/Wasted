
using Wasted.API.Filter;
using System;
namespace Wasted.API.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}