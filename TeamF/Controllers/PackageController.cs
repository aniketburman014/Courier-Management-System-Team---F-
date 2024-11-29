//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using TeamF.Data;
//using TeamF.Models;
//using Microsoft.EntityFrameworkCore;

//namespace TeamF.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PackageController : ControllerBase
//    {
//        private readonly AppDbContext _context;

//        public PackageController(AppDbContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Package>>> GetPackages()
//        {
//            var packages = await _context.Packages
//                .Include(p => p.Customer)
//                .Include(p => p.Courier)
//                .ToListAsync();

//            return Ok(packages);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<Package>> GetPackage(int id)
//        {
//            var package = await _context.Packages
//                .Include(p => p.Customer)
//                .Include(p => p.Courier)
//                .FirstOrDefaultAsync(p => p.PackageID == id);

//            if (package == null)
//            {
//                return NotFound();
//            }

//            return Ok(package);
//        }

//        [HttpPost]
//        public async Task<ActionResult<Package>> BookPackage(Package package)
//        {
//            var customer = await _context.Users.FindAsync(package.CustomerID);
//            if (customer == null)
//            {
//                return BadRequest("Invalid customer ID.");
//            }

//            if (string.IsNullOrEmpty(package.Status))
//            {
//                package.Status = "Pending";
//            }

//            package.CreatedAt = DateTime.Now;

//            _context.Packages.Add(package);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction(nameof(GetPackage), new { id = package.PackageID }, package);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdatePackage(int id, Package package)
//        {
//            if (id != package.PackageID)
//            {
//                return BadRequest("Package ID mismatch.");
//            }

//            var existingPackage = await _context.Packages.FindAsync(id);
//            if (existingPackage == null)
//            {
//                return NotFound();
//            }

//            existingPackage.PickupAddress = package.PickupAddress;
//            existingPackage.DeliveryAddress = package.DeliveryAddress;
//            existingPackage.Weight = package.Weight;
//            existingPackage.Status = package.Status;

//            if (package.CourierID != null)
//            {
//                existingPackage.CourierID = package.CourierID;
//            }

//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeletePackage(int id)
//        {
//            var package = await _context.Packages.FindAsync(id);
//            if (package == null)
//            {
//                return NotFound();
//            }

//            _context.Packages.Remove(package);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        [HttpPut("{id}/assign-courier")]
//        public async Task<IActionResult> AssignCourier(int id, int courierId)
//        {
//            var package = await _context.Packages.FindAsync(id);
//            if (package == null)
//            {
//                return NotFound();
//            }

//            var courier = await _context.Couriers.FindAsync(courierId);
//            if (courier == null)
//            {
//                return BadRequest("Invalid courier ID.");
//            }

//            package.CourierID = courierId;
//            package.Status = "In Transit";

//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//    }
//}
