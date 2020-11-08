
namespace Phonebook.Helpers.Interfaces
{
    public interface IMappingHelper
    {
        TDestination Map<TDestination, TSource>(TSource obj);
    }
}
