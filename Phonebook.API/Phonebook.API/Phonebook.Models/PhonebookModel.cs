
using System.Collections.Generic;

namespace Phonebook.Models
{
    public class PhonebookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EntryModel> Entries { get; set; }
    }
}
