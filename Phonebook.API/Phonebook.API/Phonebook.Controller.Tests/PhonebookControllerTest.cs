using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook.API.Controllers;
using Phonebook.Components;
using Phonebook.Data;
using Phonebook.Data.Entities;
using Phonebook.Helpers.MappingProfiles;
using Phonebook.Models.ApiRequest;
using Phonebook.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace Phonebook.Controller.Tests
{
    public class PhonebookControllerTest
    {
        private int _phonebookId = 1;
        private readonly PhonebookController _phonebookController;
        public PhonebookControllerTest()
        {
            DbContextOptions dbOptions = new DbContextOptionsBuilder<PhonebookContext>()
                .UseInMemoryDatabase(databaseName: "Phonebook")
                .Options;
            PhonebookContext context = new PhonebookContext(dbOptions);
            PhonebookContextSeed.SeedAsync(context).Wait();

            PhonebookRepository phoneboookRepository = new PhonebookRepository(context);

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EntryProfile>();
                cfg.CreateMap<AddEntryModel, EntryEntity>();
            });
            PhonebookComponent phonebookComponent = new PhonebookComponent(phoneboookRepository);
            _phonebookController = new PhonebookController(phonebookComponent);
        }
        [Fact]
        public async Task GetEntries()
        {
            IActionResult result = await _phonebookController.GetEntries(_phonebookId);
            OkObjectResult okResult = result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
