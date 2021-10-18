using MementoService.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MementoService.Services
{
    public class Memento
    {
        private readonly IMongoCollection<MementoModel> _crud;

        public Memento(IDatabaseSettings settings)
        {
            var client = new MongoClient("mongodb://mementoservicedb:27017");
            var database = client.GetDatabase(settings.DatabaseName);
            _crud = database.GetCollection<MementoModel>(settings.MementosCollectionName);
        }

        public void Create(MementoModel memento)
        {
            _crud.InsertOne(memento);
        }

        public MementoModel Get(string userID, int index) =>
            _crud.Find(memento => memento.UserID == userID && memento.Index == index).FirstOrDefault();

        public void Remove(string userID, int index) =>
            _crud.DeleteOne(memento => memento.UserID == userID && memento.Index == index);

        public void RemoveThisAndAfter(string userID, int index) =>
            _crud.DeleteMany(memento => memento.UserID == userID && memento.Index >= index);
    }
}
