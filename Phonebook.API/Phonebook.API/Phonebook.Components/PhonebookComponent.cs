using Phonebook.Components.Interfaces;
using Phonebook.Models;
using Phonebook.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Phonebook.Components
{
    public class PhonebookComponent : IPhonebookComponent
    {
        private readonly IPhonebookRepository _phonebookRepository;
        public PhonebookComponent(IPhonebookRepository phonebookRepository)
        {
            _phonebookRepository = phonebookRepository;
        }
        public async Task<PhonebookModel> GetEntries(int phonebookId)
        {
            return await  _phonebookRepository.GetPhonebookWithEntries(phonebookId);
        }
    }
}
