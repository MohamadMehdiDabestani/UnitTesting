using Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class PersonServices : IPersonServices
    {
        private readonly List<Person> _list;

        public PersonServices()
        {
            _list = new List<Person>() {
                new Person()
                {
                    Id = 1,
                    LName = "Dabestani",
                    Name = "Mohammad"
                },
                new Person()
                {
                    Id = 2,
                    LName = "Fallah",
                    Name = "Mohammad Reza"
                },
                new Person()
                {
                    Id = 3,
                    LName = "Dabestani",
                    Name = "Ali"
                },
                new Person()
                {
                    Id = 4,
                    LName = "Mirmirani",
                    Name = "Jadi"
                },
            };
        }

        public Person Add(Person p)
        {
            _list.Add(p);
            return p;
        }

        public void Delete(int id)
        {
            var person = Get(id);
            _list.Remove(person);
        }

        public Person Edite(Person p)
        {
            var person = Get(p.Id);

            if (person == null)
                return null;
            person.Name = p.Name;
            person.LName = p.LName;
            _list.Remove(person);
            _list.Add(person);
            return person;
        }

        public Person Get(int id)
        {
            return _list.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Person> GetAll()
        {
            return _list;
        }
    }
}
