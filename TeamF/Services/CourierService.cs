using Microsoft.EntityFrameworkCore;
using TeamF.Data;
using TeamF.Models;

namespace TeamF.Services
{
    public class CourierService
    {
        private readonly AppDbContext _context;

        public CourierService(AppDbContext context)
        {
            _context = context;
        }

        // Create Courier
        public async Task<Courier> CreateCourierAsync(Courier courier)
        {
            _context.Couriers.Add(courier);
            await _context.SaveChangesAsync();
            return courier;
        }

        // Get Courier by ID
        public async Task<Courier> GetCourierByIdAsync(int courierId)
        {
            return await _context.Couriers.FindAsync(courierId);
        }

        // Get All Couriers
        public async Task<IEnumerable<Courier>> GetAllCouriersAsync()
        {
            return await _context.Couriers.ToListAsync();
        }

        // Update Courier
        public async Task<Courier> UpdateCourierAsync(Courier courier)
        {
            _context.Couriers.Update(courier);
            await _context.SaveChangesAsync();
            return courier;
        }

        // Delete Courier
        public async Task<bool> DeleteCourierAsync(int courierId)
        {
            var courier = await _context.Couriers.FindAsync(courierId);
            if (courier == null) return false;

            _context.Couriers.Remove(courier);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
