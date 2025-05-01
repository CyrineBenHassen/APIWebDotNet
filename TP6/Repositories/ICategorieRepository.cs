
using TP6.Models;


namespace TP6.Repositories
{
    public interface ICategorieRepository
    {

        Task<IEnumerable<Categorie>> GetAll();
        Task<Categorie?> GetById(int id);
        Task<Categorie> Add(Categorie categorie);
        Task<Categorie?> Update(int id, Categorie categorie);
        Task<bool> Delete(int id);
    }
}
