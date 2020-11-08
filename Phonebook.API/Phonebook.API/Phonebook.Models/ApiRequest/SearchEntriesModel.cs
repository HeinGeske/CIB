using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Models.ApiRequest
{
    public class SearchEntriesModel
    {
        public int PhonebookId { get; set; }
        public string Search { get; set; }
    }
}
