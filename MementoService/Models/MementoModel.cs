using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MementoService.Models
{
    public class MementoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        public string UserID { get; set; }

        public int Index { get; set; }

        public string State { get; set; }

        public MementoModel(string userID, int index, string state)
        {
            UserID = userID;
            Index = index;
            State = state;
        }
    }
}