using Phonebook.Data;
using Phonebook.Data.Entities;
using Phonebook.Models;
using Phonebook.Repositories.Base;
using Phonebook.Repositories.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Phonebook.Repositories
{
    public class PhonebookRepository : RepositoryBase<PhonebookEntity>, IPhonebookRepository
    {
        Expression<Func<PhonebookEntity, PhonebookModel>> modelExpression = x => new PhonebookModel() { Id = x.Id, Name = x.Name, Entries = x.Entries.Select(z => new EntryModel() { Id = z.Id, Name = z.Name, Number = z.Number }).ToList() };
        public PhonebookRepository(PhonebookContext dbContext) : base(dbContext)
        {

        }
        public async Task<PhonebookModel> GetPhonebookWithEntries(int id)
        {
            return await GetOneAsync(modelExpression, x => x.Id == id, null, x => x.Entries);

        }
    }
}
