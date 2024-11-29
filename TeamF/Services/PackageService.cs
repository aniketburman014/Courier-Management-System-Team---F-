using TeamF.Data;
using TeamF.Models;
using Microsoft.EntityFrameworkCore;
namespace TeamF.Services
{
    public class PackageService
    {
        private readonly AppDbContext _context;

        public PackageService(AppDbContext context)
        {
            _context = context;
        }

        // Create Package
        public async Task<Package> CreatePackageAsync(Package package)
        {
            _context.Packages.Add(package);
            await _context.SaveChangesAsync();
            return package;
        }

        // Get Package by ID
        public async Task<Package> GetPackageByIdAsync(int packageId)
        {
            return await _context.Packages
                .Include(p => p.Customer)
                .Include(p => p.Courier)
                .FirstOrDefaultAsync(p => p.PackageID == packageId);
        }

        // Get All Packages
        public async Task<IEnumerable<Package>> GetAllPackagesAsync()
        {
            return await _context.Packages
                .Include(p => p.Customer)
                .Include(p => p.Courier)
                .ToListAsync();
        }

        // Update Package
        public async Task<Package> UpdatePackageAsync(Package package)
        {
            _context.Packages.Update(package);
            await _context.SaveChangesAsync();
            return package;
        }

        // Delete Package
        public async Task<bool> DeletePackageAsync(int packageId)
        {
            var package = await _context.Packages.FindAsync(packageId);
            if (package == null) return false;

            _context.Packages.Remove(package);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
