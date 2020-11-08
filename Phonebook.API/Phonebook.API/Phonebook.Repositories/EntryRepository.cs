using Phonebook.Data;
using Phonebook.Data.Entities;
using Phonebook.Models;
using Phonebook.Repositories.Base;
using Phonebook.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Phonebook.Repositories
{
    public class EntryRepository : RepositoryBase<EntryEntity>, IEntryRepository
    {
        Expression<Func<EntryEntity, EntryModel>> modelExpression = z => new EntryModel() { Id = z.Id, Name = z.Name, Number = z.Number };
        public EntryRepository(PhonebookContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<EntryModel>> GetFilteredEntries(string search, int phonebookId)
        {
            return await GetAllAsync(modelExpression, x => x.PhonebookId == phonebookId && x.Name.ToLower().Contains(search.ToLower()));
        }

        public async Task<int> AddEntry(EntryEntity entry)
        {
            EntryEntity createdEntry = await AddAsync(entry);
            return createdEntry.Id;
        }
    }
}
