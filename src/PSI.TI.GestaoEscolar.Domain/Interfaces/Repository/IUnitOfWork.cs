using System.Threading.Tasks;

namespace PSI.TI.GestaoEscolar.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}