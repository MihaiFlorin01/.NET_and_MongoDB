using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace TestProject.API.Entities
{
    public class Job
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }
        public string JobName { get; set; }
        public decimal MinimumSalary { get; set; }
        public decimal MaximumSalary { get; set; }

    }
}
