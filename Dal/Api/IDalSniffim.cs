
using Dal.Models;

namespace Dal.Api
{
    public interface IDalSniffim
    {
        List<Snif> Get();
       void Create(Snif p);
        void Update(Snif p);
    }
}
