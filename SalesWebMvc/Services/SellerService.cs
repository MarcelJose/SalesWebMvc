using SalesWebMvc.Data;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;
using NuGet.Protocol.Plugins;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.Include(obj => obj.Department).ToList();
        }

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller FidById(int id)
        {
            var seller = _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
            if (seller == null) throw new NotFoundException("Id not found");
            return seller;
        }

        public void Remove(int id)
        {
            var seller = _context.Seller.Find(id);
            if (seller == null) throw new NotFoundException("Id not found");
            _context.Seller.Remove(seller);
            _context.SaveChanges();
        }

        public void Update(Seller seller)
        {
            if (!_context.Seller.Any(x => x.Id == seller.Id)) throw new NotFoundException("Id not found");
            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }
    }
}
