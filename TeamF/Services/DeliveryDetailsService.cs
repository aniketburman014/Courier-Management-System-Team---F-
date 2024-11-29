using TeamF.Data;
using TeamF.Models;
using Microsoft.EntityFrameworkCore;

namespace TeamF.Services
{
    public class DeliveryDetailsService
    {
        private readonly AppDbContext _context;

        public DeliveryDetailsService(AppDbContext context)
        {
            _context = context;
        }

        // Create DeliveryDetail
        public async Task<DeliveryDetails> CreateDeliveryDetailAsync(DeliveryDetails deliveryDetail)
        {
            _context.DeliveryDetails.Add(deliveryDetail);
            await _context.SaveChangesAsync();
            return deliveryDetail;
        }

        // Get DeliveryDetail by ID
        public async Task<DeliveryDetails> GetDeliveryDetailByIdAsync(int deliveryId)
        {
            return await _context.DeliveryDetails
                .Include(d => d.Package)
                .FirstOrDefaultAsync(d => d.DeliveryID == deliveryId);
        }

        // Get All DeliveryDetails
        public async Task<IEnumerable<DeliveryDetails>> GetAllDeliveryDetailsAsync()
        {
            return await _context.DeliveryDetails
                .Include(d => d.Package)
                .ToListAsync();
        }

        // Update DeliveryDetail
        public async Task<DeliveryDetails> UpdateDeliveryDetailAsync(DeliveryDetails deliveryDetail)
        {
            _context.DeliveryDetails.Update(deliveryDetail);
            await _context.SaveChangesAsync();
            return deliveryDetail;
        }

        // Delete DeliveryDetail
        public async Task<bool> DeleteDeliveryDetailAsync(int deliveryId)
        {
            var deliveryDetail = await _context.DeliveryDetails.FindAsync(deliveryId);
            if (deliveryDetail == null) return false;

            _context.DeliveryDetails.Remove(deliveryDetail);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
