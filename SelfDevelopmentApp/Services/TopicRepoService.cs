using SelfDevelopmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Services
{
    public class TopicRepoService : ITopicRepository
    {

        public AppDbContext AppDbContext { get; }
        public TopicRepoService(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public List<Topic> AllTopics()
        {
            return AppDbContext.Topics.ToList();
        }

        public void DeleteTopic(int id)
        {
            Topic topic = AppDbContext.Topics.FirstOrDefault(t => t.ID == id);
            AppDbContext.Topics.Remove(topic);
        }

        public void EditTopic(int id, Topic topic)
        {
            Topic editedTopic = AppDbContext.Topics.Find(id);
            editedTopic.Name = topic.Name;
            AppDbContext.SaveChanges();
        }

        public Topic GetTopicByID(int id)
        {
            return AppDbContext.Topics.FirstOrDefault(t => t.ID == id);
        }

        public Topic GetTopicByName(string name)
        {
            return AppDbContext.Topics.FirstOrDefault(t => t.Name == name);
        }

        public void InsertTopic(Topic topic)
        {
            AppDbContext.Topics.Add(topic);
            AppDbContext.SaveChanges();
        }
    }
}
