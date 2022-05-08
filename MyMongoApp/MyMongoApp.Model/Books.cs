using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMongoApp.Model
{
    public class Books : IEntity<int>
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)] // string id created from new ObjectId()
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Copies  { get; set; }
        public string Contents { get; set; } = string.Empty;
    }
}