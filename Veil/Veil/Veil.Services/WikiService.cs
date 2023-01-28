using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veil.Data.Literature;

namespace Veil.Services
{
    public class WikiService
    {

        public MongoClient MongoClient { get; set; }
        public IMongoDatabase WikiDatabase { get; set; }
        public IMongoCollection<WikipediaArticle> WikiPages { get; set; }

        public WikiService()
        {
            MongoClient = GetMongoClient();
            WikiDatabase = MongoClient.GetDatabase("enwiki");
            WikiPages = WikiDatabase.GetCollection<WikipediaArticle>("pages");
        }

        public MongoClient GetMongoClient()
        {
            return new MongoClient( "mongodb://localhost:27017");
        }

        public WikipediaArticle GetArticleWithTitle(string Title)
        {
            var foundPage = WikiPages.Find(x => x._id == Title.Capitalize()).FirstOrDefault();
            // FIXME, this below code does work and fairly quickly
            // however it is having those issue with the structure it 
            // deserializes into, so need to fix that and we can get autocomplete working.
            var foundPages = WikiPages.Find(x => x._id.Contains(Title.Capitalize())).ToList();
            return foundPage;
        }
    }
}
