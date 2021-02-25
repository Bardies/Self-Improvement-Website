using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelfDevelopmentApp.Models;
using SelfDevelopmentApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SelfDevelopmentApp.Controllers
{
    public class ArticlesController : Controller
    {

        private readonly IArticleRepository articleRepository;
        private readonly ITopicRepository topicRepository;
        //private readonly IHttpContextAccessor httpContextAccessor;
        static List<Article> selectedArticles;
        public ArticlesController(IArticleRepository _articleRepository , ITopicRepository _topicRepository/*, IHttpContextAccessor _httpContextAccessor*/)
        {
            articleRepository = _articleRepository;
            topicRepository = _topicRepository;
            //httpContextAccessor = _httpContextAccessor;
            //CookieOptions cookieOptions = new CookieOptions();
            //HttpContext.Response.Cookies.Append(
            //         "name", "value", cookieOptions);

        }
        // GET: ArticlesController
        public ActionResult Index()
        {
            selectedArticles = null;
            List<Article> articles = articleRepository.AllArticles();
            ViewBag.NumOfItems = articles.Count;
            ViewBag.Topics = topicRepository.AllTopics();
            ViewBag.pageNum = 1;
            return View(articles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IFormCollection collection)
        {
            ViewBag.Topics = topicRepository.AllTopics();
            
            if (int.TryParse(collection["name"], out int num))
            {
                List<Article> articles;
                if (selectedArticles != null && selectedArticles.Count!=0)
                    articles = selectedArticles;
               
                else
                    articles = articleRepository.AllArticles();
                
                ViewBag.NumOfItems = articles.Count;
                ViewBag.pageNum = num;
                return View(articles);
            }
            else
            {
                ViewBag.pageNum = 1;
                List<Article> articles = articleRepository.GetArticlesByTitle(collection["name"]);

                Topic topic = topicRepository.GetTopicByName(collection["name"]);
                if (topic != null)
                    articles.AddRange(articleRepository.GetArticlesByTopic(topic));

                if (articles != null && articles.Count > 0)
                {
                    ViewBag.NumOfItems = articles.Count;
                    selectedArticles = articles;
                    return View(articles);
                }
                return View();
            }
        }


        // GET: ArticlesController/Details/5
        public ActionResult Details(int? id)
        {
            var article = articleRepository.GetArticleByID(id);
            if(article==null)
            {
                return NotFound();
            }
            ViewBag.RelatedArticles = articleRepository.GetArticlesByTopic(article.Topic);
            return View(article);
        }

        // GET: ArticlesController/Create
        public ActionResult Create()
        {
            ViewBag.Topics = topicRepository.AllTopics();
            return View();
        }

        // POST: ArticlesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ID,Title,Author,Text,Image,TopicID")] Article article)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    articleRepository.InsertArticle(article);
                    return RedirectToAction(nameof(Index));
                } 
                catch
                {
                    return View(article);
                }
            }
            return View(article);

        }

        // GET: ArticlesController/Edit/5
        public ActionResult Edit(int? id)
        {
            var article = articleRepository.GetArticleByID(id);
            if (article == null)
                return NotFound();

            ViewBag.Topics = topicRepository.AllTopics();
            return View(article);
        }

        // POST: ArticlesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("ID,Title,Author,Text,Image,TopicID")] Article article)
        {
            if (id != article.ID)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    articleRepository.EditArticle(id, article);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(article);
                }
            }
            return View(article);

        }

        // GET: ArticlesController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = articleRepository.GetArticleByID(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: ArticlesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Article article)
        {
            try
            {
                articleRepository.DeleteArticle(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(article);
            }
        }
    }
}
