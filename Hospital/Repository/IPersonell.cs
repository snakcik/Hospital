using Hospital.Dtos;

namespace Hospital.Repository
{
    public interface IPersonell : IBaseRepository<PersonellDto>
    {
        bool AddBool (PersonellDto entity);
    }
}
