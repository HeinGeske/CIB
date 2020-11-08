
namespace Phonebook.Data.Entities.Base
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}
