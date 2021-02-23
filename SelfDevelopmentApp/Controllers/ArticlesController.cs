using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelfDevelopmentApp.Models;
using SelfDevelopmentApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleRepository articleRepository;
        private readonly ITopicRepository topicRepository;

        public ArticlesController(IArticleRepository _articleRepository , ITopicRepository _topicRepository)
        {
            articleRepository = _articleRepository;
            topicRepository = _topicRepository;
        }
        // GET: ArticlesController
        public ActionResult Index()
        {
            return View(articleRepository.AllArticles());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IFormCollection collection)
        {
            Topic topic = topicRepository.GetTopicByName(collection["name"]);
            if(topic!=null)
                return View(articleRepository.GetArticlesByTopic(topic));
            return View();
        }

        // GET: ArticlesController/Details/5
        public ActionResult Details(int? id)
        {
            var article = articleRepository.GetArticleByID(id);
            if(article==null)
            {
                return NotFound();
            }
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
