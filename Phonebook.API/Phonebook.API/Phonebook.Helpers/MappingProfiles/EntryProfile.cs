
using AutoMapper;
using Phonebook.Data.Entities;
using Phonebook.Models.ApiRequest;

namespace Phonebook.Helpers.MappingProfiles
{
    public class EntryProfile : Profile
    {
        public EntryProfile()
        {
            CreateMap<AddEntryModel, EntryEntity>();
        }
    }
}
