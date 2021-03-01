using SelfDevelopmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Services
{
    public interface IArticleRepository
    {
        public List<Article> AllArticles();   /// Index => List All

        public List<Article> GetArticlesByTitle(string title);   /// get articles by tile

        public List<Article> GetArticlesByTopic(Topic topic);   /// get articles by topic name

        public Article GetArticleByID(int id);  /// Details

        public void InsertArticle(Article article);  /// Create

        public void EditArticle(int id, Article article);  /// Edit

        public void DeleteArticle(int id);   /// Delete
    }
}
