using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Repos
{
    public class OffersRepo : IOffersRepo
    {
        readonly ISPContext context;
        public OffersRepo(ISPContext _context)
        {
            this.context = _context;
        }
        public List<Offer> GetAll()=> context.Offers.Include(offer => offer.Package).ToList();
        public Offer GetById(int id) => context.Offers.Include(offer => offer.Package).FirstOrDefault(offer => offer.Id == id);
        
        public List<string> getOffers () => context.Offers.Select(B => B.Name).ToList();
        public void Create(OffersViewModel offersView)
        {
            Offer offer = new Offer()
            {
                Name = offersView.OfferName,
                StartDate = offersView.StartDate,
                Duration = offersView.Duration,
                Discount = offersView.Discount,
                Cancel = offersView.Cancel,
                PackageId = offersView.PackageId
            };
            context.Offers.Add(offer);
            context.SaveChanges();
        }
        public OffersViewModel Update(int id, OffersViewModel offersView)
        {
            Offer offer = context.Offers.Find(id);
            offer.Name = offersView.OfferName;
            offer.StartDate = offersView.StartDate;
            offer.Discount = offersView.Discount;
            offer.Cancel = offersView.Cancel;
            offer.PackageId = offersView.PackageId;

            context.SaveChanges();
            return offersView;
        }
        public void Delete(int id)
        {
            Offer offer = context.Offers.Find(id);
            context.Offers.Remove(offer);
            context.SaveChanges();
        }
    }
}
