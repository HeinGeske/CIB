using Phonebook.Data.Entities.Base;
using System.Collections.Generic;

namespace Phonebook.Data.Entities
{
    public class PhonebookEntity : Entity
    {
        public string Name { get; set; }
        public ICollection<EntryEntity> Entries { get; private set; }
        public PhonebookEntity()
        {
            Entries = new List<EntryEntity>();
        }

    }
}
