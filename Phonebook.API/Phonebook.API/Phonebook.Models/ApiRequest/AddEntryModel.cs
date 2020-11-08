using System.ComponentModel.DataAnnotations;

namespace Phonebook.Models.ApiRequest
{
    public class AddEntryModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Number { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int PhonebookId { get; set; }
    }
}
