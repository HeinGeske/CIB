using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Data.Entities;
using Phonebook.Models;
using Phonebook.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Phonebook.Repositories.Tests
{
    public class EntryTests
    {
        private string _searchName = "Bianca";
        private string _newName = "New Entry";
        private string _newNumber = "0123654789";
        private int _phonebookId = 1;
        private int _phonebookCount = 0;
        private readonly PhonebookContext _context;
        private readonly IEntryRepository _entryRepository;

        public EntryTests()
        {
            DbContextOptions dbOptions = new DbContextOptionsBuilder<PhonebookContext>()
                .UseInMemoryDatabase(databaseName: "Phonebook")
                .Options;
            _context = new PhonebookContext(dbOptions);
            PhonebookContextSeed.SeedAsync(_context).Wait();
            _entryRepository = new EntryRepository(_context);
            _phonebookCount = _entryRepository.GetAllAsync().Result.Count;
        }

        [Fact]
        public async Task GetFilteredEntries()
        {
            List<EntryModel> entries = await _entryRepository.GetFilteredEntries(_searchName, _phonebookId);
            Assert.Equal(_searchName,entries[0].Name);
        }

        [Fact]
        public async Task AddEntry()
        {
            int createdId = await _entryRepository.AddEntry(new EntryEntity()
            {
                Name = _newName,
                Number = _newNumber,
                PhonebookId = _phonebookId
            });

             List<EntryEntity> entries = await  _entryRepository.GetAllAsync();
            Assert.NotEqual(entries.Count, _phonebookCount);
        }
    }
}
