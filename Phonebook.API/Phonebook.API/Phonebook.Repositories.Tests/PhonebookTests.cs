using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;
using Phonebook.Repositories.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace Phonebook.Repositories.Tests
{
    public class PhonebookTests
    {
        private int _phonebookId = 1;
        private readonly PhonebookContext _context;
        private readonly IPhonebookRepository _phonebookRepository;
        public PhonebookTests()
        {
            DbContextOptions dbOptions = new DbContextOptionsBuilder<PhonebookContext>()
                .UseInMemoryDatabase(databaseName: "Phonebook")
                .Options;
            _context = new PhonebookContext(dbOptions);
            PhonebookContextSeed.SeedAsync(_context).Wait();
            _phonebookRepository = new PhonebookRepository(_context);
        }

        [Fact]
        public async Task GetPhonebookFromId()
        {
            PhonebookModel phonebook = await _phonebookRepository.GetPhonebookWithEntries(_phonebookId);
            Assert.Equal(_phonebookId, phonebook.Id);
        }
    }
}
