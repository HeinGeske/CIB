using Phonebook.Models;
using System.Threading.Tasks;

namespace Phonebook.Components.Interfaces
{
    public interface IPhonebookComponent
    {
        Task<PhonebookModel> GetEntries(int phonebookId);
    }
}
