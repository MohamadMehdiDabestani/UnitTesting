using Api.Controllers;
using Api.Model;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace Testing.API
{
    public class BooksControllerTest
    {
        PersonController _controller;
        IPersonServices _person;
        Person _update;
        public BooksControllerTest()
        {
            _update = new Person
            {
                Id = 4,
                LName = "Rahimi",
                Name = "Sara"
            };
            _person = new PersonServices();
            _controller = new PersonController(_person);
        }
        [Fact]
        public void GetAllTest()
        {
            var res = _controller.GetAll();

            Assert.IsType<OkObjectResult>(res);

            var list = res as OkObjectResult;
            Assert.IsType<List<Person>>(list.Value);

            var listPerson = list.Value as List<Person>;
            Assert.Equal(4, listPerson.Count);
        }
        [Theory]
        [InlineData(4,7)]
        public void GetTest(int x , int y)
        {
            var notFoundResult = _controller.Get(y);
            var okResult = _controller.Get(x);

            Assert.IsType<NotFoundResult>(notFoundResult);
            Assert.IsType<OkObjectResult>(okResult);

            var item = okResult as OkObjectResult;
            Assert.IsType<Person>(item.Value);

            var personItem = item.Value as Person;
            Assert.Equal(x , personItem.Id);
            Assert.Equal("Jadi", personItem.Name);
        }
        [Fact]
        public void AddTest()
        {
            var person = new Person()
            {
                Id = 5,
                Name = "Sian",
                LName = "Harchi"
            };
            var createResponse = _controller.Add(person);
            Assert.IsType<CreatedAtActionResult>(createResponse);

            var item = createResponse as CreatedAtActionResult;
            Assert.IsType<Person>(item.Value);

            var itemPerson = item.Value as Person;
            Assert.Equal(person.Name, itemPerson.Name);
            Assert.Equal(person.LName, itemPerson.LName);
            Assert.Equal(person.Id, itemPerson.Id);

            // invalid
            var invalidPerson = new Person
            {
                Name = "Sian",
                LName = "Harchi"
            };
            _controller.ModelState.AddModelError("Id", "Id key is required");
            var invalidResponse = _controller.Add(invalidPerson);
            Assert.IsType<BadRequestResult>(invalidResponse);
        }
        [Fact]
        public void UpdateTest()
        {
            var res = _controller.Update(_update);
            Assert.IsType<OkObjectResult>(res);
            var item = res as OkObjectResult;
            Assert.IsType<Person>(item.Value);
            var itemPerson = item.Value as Person;
            Assert.Equal(_update.Name, itemPerson.Name);
            Assert.Equal(_update.LName, itemPerson.LName);
            Assert.Equal(_update.Id, itemPerson.Id);
        }
        [Theory]
        [InlineData(4)]
        public void DeleteTest(int id)
        {
            var res = _controller.Delete(id);
            Assert.IsType<NoContentResult>(res);

        }
    }
}
