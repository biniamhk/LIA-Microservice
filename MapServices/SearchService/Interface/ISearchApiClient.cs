using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using SearchService.ViewModels;
using Newtonsoft.Json;

namespace SearchService.Interface
{
    public interface ISearchApiClient
    {
        Task<List<SearchView>> GetSearchAsync(string address);
    }
}
