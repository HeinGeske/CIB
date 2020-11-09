using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook.API.Controllers;
using Phonebook.Components;
using Phonebook.Data;
using Phonebook.Data.Entities;
using Phonebook.Helpers;
using Phonebook.Helpers.MappingProfiles;
using Phonebook.Models.ApiRequest;
using Phonebook.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace Phonebook.Controller.Tests
{
    public class EntryControllerTest
    {
        private string _searchName = "Bianca";
        private int _phonebookId = 1;
        private string _newName = "New Entry";
        private string _newNumber = "0123654789";
        private readonly EntryController _entryController;
        public EntryControllerTest()
        {
            DbContextOptions dbOptions = new DbContextOptionsBuilder<PhonebookContext>()
                .UseInMemoryDatabase(databaseName: "Phonebook")
                .Options;
            PhonebookContext context = new PhonebookContext(dbOptions);
            PhonebookContextSeed.SeedAsync(context).Wait();

            EntryRepository entryRepository = new EntryRepository(context);

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EntryProfile>();
                cfg.CreateMap<AddEntryModel, EntryEntity>();
            });

            EntryComponent entryComponent = new EntryComponent(entryRepository, new MappingHelper(new Mapper(config)));

            _entryController = new EntryController(entryComponent);
        }
        [Fact]
        public async Task GetSearch()
        {
            IActionResult result = await _entryController.SearchEntries(new SearchEntriesModel()
            {
                PhonebookId = _phonebookId,
                Search = _searchName
            });
            OkObjectResult okResult = result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }
        [Fact]
        public async Task AddEntry()
        {
            IActionResult result = await _entryController.AddEntry(new AddEntryModel()
            {
                Name = _newName,
                Number = _newNumber,
                PhonebookId = _phonebookId
            });
            StatusCodeResult okResult = result as StatusCodeResult;
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
