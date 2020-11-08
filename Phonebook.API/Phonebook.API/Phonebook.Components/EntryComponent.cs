using Phonebook.Components.Interfaces;
using Phonebook.Data.Entities;
using Phonebook.Helpers.Interfaces;
using Phonebook.Models;
using Phonebook.Models.ApiRequest;
using Phonebook.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phonebook.Components
{
    public class EntryComponent : IEntryComponent
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IMappingHelper _mappingHelper;
        public EntryComponent(IEntryRepository entryRepository, IMappingHelper mappingHelper)
        {
            _entryRepository = entryRepository;
            _mappingHelper = mappingHelper;
        }
        public async Task<List<EntryModel>> GetEntriesFiltered(int id, string search)
        {
            return await _entryRepository.GetFilteredEntries(search, id);
        }
        public async Task AddEntry(AddEntryModel model)
        {
            EntryEntity entryEntity = _mappingHelper.Map<EntryEntity, AddEntryModel>(model);
            await _entryRepository.AddEntry(entryEntity);
        }
    }
}
