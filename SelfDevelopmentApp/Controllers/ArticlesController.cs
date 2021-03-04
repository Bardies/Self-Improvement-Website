using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelfDevelopmentApp.Models;
using SelfDevelopmentApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SelfDevelopmentApp.Controllers
{
    public class ArticlesController : Controller
    {

        private readonly IArticleRepository articleRepository;
        private readonly ITopicRepository topicRepository;

        // a variable to keep track of the articles that will be displayed in the index view
        // whether to be all articles (if no search or selected topic) or to be articles
        // related to selected topic from sidebar of searched word 
        static List<Article> selectedArticles;
        public ArticlesController(IArticleRepository _articleRepository , ITopicRepository _topicRepository)
        {
            articleRepository = _articleRepository;
            topicRepository = _topicRepository;
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
            
            // check if the form is submitted from the paging buttons to get the page number to be viewed
            // and send to the view page
            if (int.TryParse(collection["name"], out int num))
            {
                // view selected articels resulted from search of the topic
                List<Article> articles;
                if (selectedArticles != null && selectedArticles.Count!=0)
                    articles = selectedArticles;
               
                // view all articles in db
                else
                    articles = articleRepository.AllArticles();
                
                ViewBag.NumOfItems = articles.Count;
                ViewBag.pageNum = num;
                return View(articles);
            }
            else
            {
                // compare the parameter of form collection to articles titles and topics names and get
                // related articles to be viewed
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

    }
}
