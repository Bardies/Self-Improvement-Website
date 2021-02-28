using Microsoft.EntityFrameworkCore;
using SelfDevelopmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Services
{
    public class ArticleRepoService : IArticleRepository
    {
        private AppDbContext AppDbContext { get; }
        public ArticleRepoService(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }
        public List<Article> AllArticles()
        {
            return AppDbContext.Articles.Include(a => a.Topic).ToList();
        }

        public void DeleteArticle(int id)
        {
            Article article = AppDbContext.Articles.FirstOrDefault(a => a.ID == id);
            AppDbContext.Articles.Remove(article);
        }

        public void EditArticle(int id, Article article)
        {
            Article editedArticle = AppDbContext.Articles.Find(id);
            editedArticle.Author = article.Author;
            editedArticle.Image = article.Image;
            editedArticle.Text = article.Text;
            editedArticle.Title = article.Title;
            AppDbContext.SaveChanges();
        }

        public List<Article> GetArticlesByTitle(string title)
        {
            return AppDbContext.Articles.Where(a => a.Title == title).Include(t => t.Topic).ToList();
        }

        public void InsertArticle(Article article)
        {
            AppDbContext.Articles.Add(article);
            AppDbContext.SaveChanges();
        }

        public List<Article> GetArticlesByTopic(Topic topic)
        {
            return AppDbContext.Articles.Include(t =>t.Topic).Where(a => a.Topic.ID == topic.ID).ToList();
        }

        public Article GetArticleByID(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return AppDbContext.Articles.Include(t => t.Topic).FirstOrDefault(a => a.ID == id);
        }
    }
}
