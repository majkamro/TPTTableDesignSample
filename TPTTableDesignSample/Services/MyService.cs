using Microsoft.EntityFrameworkCore;
using TPTTableDesignSample.Context;
using TPTTableDesignSample.Dtos;
using TPTTableDesignSample.Models;

namespace TPTTableDesignSample.Services
{
    public class MyService
    {
        private readonly AppDbContext _dbContext;

        public MyService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PartiesModel>> DoSomething()
        {
            return await _dbContext.Parties
        .Select(p => new PartiesModel
        {
            PartyId = p.Id,
            PartyName = p.Name,
            CustomerName = (p as Customer) != null ? (p as Customer).CustomerSpecificProperty : string.Empty,
            SupplierCode = (p as Supplier) != null ? (p as Supplier).SupplierSpecificProperty : string.Empty
        })
        .ToListAsync();
        }
    }
}
