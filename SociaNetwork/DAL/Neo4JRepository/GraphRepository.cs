using DAL.Enteties;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Neo4JRepository
{
    public class GraphRepository
    {
        private readonly IGraphClient _graphClient;

        public GraphRepository()
        {
            _graphClient = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "socialnetwork");
            _graphClient.Connect();
        }

        //public void Setup()
        //{
        //    var people = new List<string[]>
        //    {
        //    new[] {"Jim", "Mike"}, new[] {"Jim", "Billy"}, new[] {"Anna", "Jim"},
        //    new[] {"Anna", "Mike"}, new[] {"Sally", "Anna"}, new[] {"Joe", "Sally"},
        //    new[] {"Joe", "Bob"}, new[] {"Bob", "Sally"}
        //    };

        //    _graphClient.Cypher
        //        .Unwind(people, "pair")
        //        .Merge("(u1:Person { name: pair[0] })")
        //        .Merge("(u2:Person { name: pair[1] })")
        //        .Merge("(u1)-[:KNOWS]->(u2)")
        //        .ExecuteWithoutResults();
        //}

        public IEnumerable<Person> FriendsOfAFriend(Person person)
        {
            /*
                MATCH (p:Person)-[:KNOWS]-(friend)-[:KNOWS]-(foaf)
                WHERE p.name = {p1}
                AND NOT (p)-[:KNOWS]-(foaf)
                RETURN foaf
            */

            var query = _graphClient.Cypher
                .Match("(p:Person)-[:FOLLOW]-(friend)-[:FOLLOW]-(foaf)")
                .Where((Person p) => p.Name == person.Name)
                .AndWhere("NOT (p)-[:FOLLOW]-(foaf)")
                .Return(foaf => foaf.As<Person>());
            return query.Results;
        }

        public IEnumerable<Person> CommonFriends(Person person1, Person person2)
        {
            /*
                MATCH (p:Person)-[:KNOWS]-(friend)-[:KNOWS]-(foaf:Person)
                WHERE p.name = {p1}
                AND foaf.name = {p2}
                RETURN friend
            */

            var query = _graphClient.Cypher
                .Match("(p:Person)-[:FOLLOW]-(friend)-[:FOLLOW]-(foaf:Person)")
                .Where((Person p) => p.Name == person1.Name)
                .AndWhere((Person foaf) => foaf.Name == person2.Name)
                .Return(friend => friend.As<Person>());

            return query.Results;
        }

        public void CreatePerson(Person person)
        {
            _graphClient.Cypher
                .Create("(np:Person {newPerson})")
                .WithParam("newPerson", person)
                .ExecuteWithoutResults();
        }
        public void CreatRelationShip(Person whoStartFollow , Person whomFollow)
        {
            _graphClient.Cypher
                .Match("(p1:Person {nickname: {p1NickName}})", "(p2:Person {nickname: {p2NickName}})")
                .WithParam("p1NickName", whoStartFollow.NickName)
                .WithParam("p2NickName", whomFollow.NickName)
                .Create("(p1)-[:FOLLOW]->(p2)")
                .ExecuteWithoutResults();
        }
        public void DeleteRelationShip(Person whoStopFollow,Person whomFollow)
        {
            _graphClient.Cypher
              .Match("(p1:Person {nickname: {p1NickName}})-[r:FOLLOW]->(p2:Person {nickname: {p2NickName}})")
              .WithParam("p1NickName", whoStopFollow.NickName)
              .WithParam("p2NickName", whomFollow.NickName)
              .Delete("r")
              .ExecuteWithoutResults();
        }

    }
}
