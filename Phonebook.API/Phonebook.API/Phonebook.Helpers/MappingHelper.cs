using AutoMapper;
using Phonebook.Helpers.Interfaces;

namespace Phonebook.Helpers
{
    public class MappingHelper : IMappingHelper
    {
        private readonly IMapper _mapper;
        public MappingHelper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TDestination, TSource>(TSource obj)
        {
            return _mapper.Map<TDestination>(obj);
        }
    }
}
