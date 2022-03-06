using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace TestProject.API.Entities
{
    public class Employee
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string HireDate { get; set; }
        public decimal Salary { get; set; }
        public Job job { get; set; }
        public Department Department { get; set; }
    }
}
