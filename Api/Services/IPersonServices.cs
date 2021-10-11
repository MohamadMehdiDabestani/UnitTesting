using Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IPersonServices
    {
        IEnumerable<Person> GetAll();
        Person Get(int id);
        Person Add(Person p);
        Person Edite(Person p);
        void Delete(int id);
    }
}
