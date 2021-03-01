using SelfDevelopmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Services
{
    public interface ITopicRepository
    {
        public List<Topic> AllTopics();  /// Index => List All

        public Topic GetTopicByID(int id);  /// Details

        public void InsertTopic(Topic article);  /// Create

        public void EditTopic(int id, Topic article);  /// Edit

        public void DeleteTopic(int id);   /// Delete

        public Topic GetTopicByName(string name);
    }
}
