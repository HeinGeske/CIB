using Phonebook.Models;
using Phonebook.Models.ApiRequest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phonebook.Components.Interfaces
{
    public interface IEntryComponent
    {
        Task<List<EntryModel>> GetEntriesFiltered(int id, string search);
        Task AddEntry(AddEntryModel model);
    }
}
