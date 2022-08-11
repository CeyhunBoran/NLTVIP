using Testapi.Data.Models;

namespace Testapi.Services
{
    public interface IContentService
    {
        public void InsertJson(string filePath, Content content);
        public List<Content> UpdateJson(string filePath, Content content);
        public void DeleteJson(string filePath, Content content);
        public IEnumerable<string> GetMenuItems();
        public IList<string> GetCategoriesByMenu(string menuName);
        public IList<Content> GetMoviesByCategory(string categoryPath);
        public Content GetMovieById(string id);
    }
}
