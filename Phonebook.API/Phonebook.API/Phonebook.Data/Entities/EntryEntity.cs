
using Phonebook.Data.Entities.Base;

namespace Phonebook.Data.Entities
{
    public class EntryEntity : Entity
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public int PhonebookId { get; set; }
        public PhonebookEntity Phonebook { get; set; }
    }
}
