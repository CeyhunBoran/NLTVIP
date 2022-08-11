using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Text.Json;
using Testapi.Data.Models;
using Testapi.Repositories;

namespace Testapi.Services
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _repository;
        private const string cacheKey = "content";

        public ContentService(IMemoryCache memoryCache, IContentRepository repository)
        {
            
            _repository = repository;
        }

        public void DeleteJson(string filePath, Content content)
        {
            throw new NotImplementedException();
        }

        public List<Content> UpdateJson(string filePath, Content content)
        {
            throw new NotImplementedException();
        }

        public void InsertJson(string filePath, Content content)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<string> GetMenuItems()
        {
            return _repository.GetMenuItems();
        }
        public IList<string> GetCategoriesByMenu(string menuName)
        {
            return _repository.GetCategoriesByMenu(menuName);
        }

        //public Root GetMoviesByCategory(string menu, string category)
        //{
        //    Root root = new Root();
        //    root.Contents = new List<Content>();
        //    var contents = _root.Contents;
        //    root.Contents =
        //    root.Contents.Concat(contents.Where(t => t.Category.Where(v => v.Split('/').Where(k => k == category).Any()).Any())).ToList();
        //    foreach (var item in contents)
        //    {
        //        foreach (var x in item.Category)
        //        {
        //            if ((x.Split('/').ElementAt(0) == menu) && (x.Split('/').ElementAt(1) == category))
        //            {
        //                root.Contents.Add(item);
        //            }
        //        }
        //    }
        //    root.Contents = contents.SelectMany(item => item.Category.Where(x => (x.Split('/').ElementAt(0) == menu) && (x.Split('/').ElementAt(1) == category)).Select(x => item)).ToList();


        //    return root;
        //}
        public IList<Content> GetMoviesByCategory(string categoryPath)
        {
            return _repository.GetMoviesByCategory(categoryPath);
        }

        public Content GetMovieById(string id)
        {
            return _repository.GetMovieById(id);
        }
    }
}

