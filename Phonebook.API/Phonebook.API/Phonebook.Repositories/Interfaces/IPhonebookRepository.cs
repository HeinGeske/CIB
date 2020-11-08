using Phonebook.Data.Entities;
using Phonebook.Models;
using Phonebook.Repositories.Interfaces.Base;
using System.Threading.Tasks;

namespace Phonebook.Repositories.Interfaces
{
    public interface IPhonebookRepository : IRepositoryBase<PhonebookEntity>
    {
        Task<PhonebookModel> GetPhonebookWithEntries(int id);
    }
}
