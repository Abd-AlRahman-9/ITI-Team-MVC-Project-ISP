using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Repos
{
    public interface IOffersRepo
    {
        public List<Offer> GetAll();
        public Offer GetById(int id);
        public void Create(OffersViewModel offersView);
        public OffersViewModel Update(int id, OffersViewModel offersView);
        public void Delete(int id);
    }
}
