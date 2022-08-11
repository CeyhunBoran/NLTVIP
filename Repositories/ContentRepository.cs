using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Testapi.Data.Models;

namespace Testapi.Repositories
{
    public class ContentRepository : IContentRepository
    {
        private Root _root { get; set; }
        private readonly IMemoryCache _memoryCache;
        private const string categories = "categories";
        private const string main = "main";
        private const string all = "all";

        public ContentRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _root = GetAll();
        }
        #region ControllerMethods
        /// <summary>
        /// Service Method: IList<string> GetMenuItems()
        /// 
        /// </summary>
        /// <returns>IList<string></returns>
        public IEnumerable<string> GetMenuItems()
        {
            IList<MainCategory> allCategories = new List<MainCategory>();
            if (_memoryCache.TryGetValue(main, out allCategories))
            {
                return allCategories.Select(v=>v.Name);
            }
            var contents = GetAll().Contents;

            allCategories = contents.SelectMany(t => t.Category.SelectMany(k => k.Split("/").Take(1))).Distinct().Select(t => new MainCategory { Name = t }).ToList();
            
            _memoryCache.Set(main, allCategories);
            return allCategories.Select(v => v.Name);
        }
        ///<summary>
        ///    Service Method: GetCategoriesByMenu(string menuName)
        ///</summary>
        public IList<string> GetCategoriesByMenu(string menuName)
        {
            List<string> result = new List<string>();
            IList<SubCategory> subCategories = new List<SubCategory>();
            IList<MainCategory> mainCategories = new List<MainCategory>();
            if (_memoryCache.TryGetValue(main, out mainCategories))
            {
                if (_memoryCache.TryGetValue(categories, out subCategories))
                {

                }
                var contentsInner = GetAll();
                result = GetCategoriesResult(menuName, contentsInner);

                subCategories = new List<SubCategory>();
                result.ForEach(t => subCategories.Add(new SubCategory { ParentName = (result == null) ? "" : menuName, Name = t }));
                _memoryCache.Set(categories, subCategories);
                return result;
            }
            mainCategories = GetMainCategories();
            var contents = GetAll();
            result = GetCategoriesResult(menuName, contents);
            subCategories = new List<SubCategory>();
            result.ForEach(t => subCategories.Add(new SubCategory { ParentName = (result == null) ? "" : menuName, Name = t }));

            _memoryCache.Set(main, mainCategories);
            _memoryCache.Set(categories, subCategories);
            return result;
        }
        ///<summary>
        ///    GetMoviesByCategory(string categoryPath)
        ///</summary>
        public IList<Content> GetMoviesByCategory(string categoryPath)
        {
            Root root = new Root();
            root.Contents = new List<Content>();
            var contents = _root.Contents;
            root.Contents = contents
                .Where(item =>
                    item.Category
                    .Where(x =>
                        x.StartsWith(categoryPath.Split("/").FirstOrDefault())
                        && x.Split("/").Skip(1).Where(v => categoryPath.Split("/").Skip(1).Contains(v)).Any()
                     ).Any()
                ).ToList();
            return root.Contents;
        }
        ///<summary>
        ///    Service Method: GetMovieById(string id)
        ///</summary>
        public Content GetMovieById(string id)
        {
            Content result = new Content();
            var contents = _root.Contents;


            return contents.Where(t => t.Id == id).FirstOrDefault();
        }
        #endregion

        #region HelperMethods
        public IList<MainCategory> GetMainCategories()
        {
            List<MainCategory> allCategories = new List<MainCategory>();
            List<string> result = new List<string>();
            var contents = GetAll().Contents;
            allCategories = contents.SelectMany(t => t.Category.SelectMany(k => k.Split("/").Take(1))).Distinct().Select(t => new MainCategory { Name = t }).ToList();
            allCategories.ForEach(c => result.Add(c.Name));
            _memoryCache.Set(main, allCategories);
            return allCategories;
        }
        public Root GetAll(string filePath = "contents.json")
        {
            _root = _memoryCache.Get<Root>(all);
            if (_root == null)
            {
                string json = File.ReadAllText(filePath);
                _root = JsonConvert.DeserializeObject<Root>(json);
                _memoryCache.Set<Root>(all, _root);
                return _root;
            }
            return _root;
        }
        public List<string> GetCategoriesResult(string menuName, Root contents)
        {
            List<string> result = new List<string>();
            //Bug
            result = contents.Contents
                .Where(t => t.Category.Where(k => k.Split('/').FirstOrDefault() == menuName).Any())
                    .SelectMany(t => t.Category.Where(k => k.Split('/').FirstOrDefault() == menuName).SelectMany(v => v.Split('/').Skip(1)).ToList()
                ).Distinct().ToList();
            List<SubCategory> subCategories = new List<SubCategory>();


            return result;

        }
        #endregion


        public List<Content> UpdateJson(string filePath, Content content)
        {
            throw new NotImplementedException();
        }

        public void InsertJson(string filePath, Content content)
        {
            throw new NotImplementedException();
        }
        public void DeleteJson(string filePath, Content content)
        {
            throw new NotImplementedException();
        }
    }
}
