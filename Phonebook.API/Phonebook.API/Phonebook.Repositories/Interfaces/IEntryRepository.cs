using Phonebook.Data.Entities;
using Phonebook.Models;
using Phonebook.Repositories.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phonebook.Repositories.Interfaces
{
    public interface IEntryRepository : IRepositoryBase<EntryEntity>
    {
        Task<List<EntryModel>> GetFilteredEntries(string search, int phonebookId);
        Task<int> AddEntry(EntryEntity entry);
    }
}
