using TeamF.Data;
using TeamF.Models;
using Microsoft.EntityFrameworkCore;
namespace TeamF.Services
{
    public class TrackingService
    {
        private readonly AppDbContext _context;

        public TrackingService(AppDbContext context)
        {
            _context = context;
        }

        // Create Tracking
        public async Task<Tracking> CreateTrackingAsync(Tracking tracking)
        {
            _context.Trackings.Add(tracking);
            await _context.SaveChangesAsync();
            return tracking;
        }

        // Get Tracking by ID
        public async Task<Tracking> GetTrackingByIdAsync(int trackingId)
        {
            return await _context.Trackings
                .Include(t => t.Package)
                .FirstOrDefaultAsync(t => t.TrackingID == trackingId);
        }

        // Get All Trackings
        public async Task<IEnumerable<Tracking>> GetAllTrackingsAsync()
        {
            return await _context.Trackings
                .Include(t => t.Package)
                .ToListAsync();
        }

        // Update Tracking
        public async Task<Tracking> UpdateTrackingAsync(Tracking tracking)
        {
            _context.Trackings.Update(tracking);
            await _context.SaveChangesAsync();
            return tracking;
        }

        // Delete Tracking
        public async Task<bool> DeleteTrackingAsync(int trackingId)
        {
            var tracking = await _context.Trackings.FindAsync(trackingId);
            if (tracking == null) return false;

            _context.Trackings.Remove(tracking);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
