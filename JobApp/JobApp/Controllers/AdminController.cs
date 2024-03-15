using JobApp.Data;
using JobApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobApp.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AdminController(ApplicationDBContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return _context.JobApplications != null ?
                        View(await _context.JobApplications.ToListAsync()) :
                        Problem("Entity set 'JobApplicationDBContext.JobApplications'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.JobApplications == null)
            {
                return NotFound();
            }

            var jobApplicationData = await _context.JobApplications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobApplicationData == null)
            {
                return NotFound();
            }

            return View(jobApplicationData);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.JobApplications == null)
            {
                return NotFound();
            }

            var jobApplicationData = await _context.JobApplications.FindAsync(id);
            if (jobApplicationData == null)
            {
                return NotFound();
            }
            return View(jobApplicationData);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, JobApplicationData jobApplicationData)
        {
            if (id != jobApplicationData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    JobApplicationDTO jobApplication = new JobApplicationDTO
                    {
                        Id = jobApplicationData.Id,
                        Name = jobApplicationData.Name,
                        Email = jobApplicationData.Email,
                        Gender = jobApplicationData.Gender,
                        Contact = jobApplicationData.Contact,
                        Address = jobApplicationData.Address,
                        PreferredLocation = jobApplicationData.PreferredLocation,
                        ExpectedCTC = jobApplicationData.ExpectedCTC,
                        CurrentCTC = jobApplicationData.CurrentCTC,
                        NoticePeriod = jobApplicationData.NoticePeriod,
                        Ccharpexperience = jobApplicationData.Ccharpexperience,
                        Mssqlexperience = jobApplicationData.Mssqlexperience,
                        dotnetexperience = jobApplicationData.dotnetexperience,
                        devopsexperience = jobApplicationData.devopsexperience,
                    };
                    _context.Update(jobApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobApplicationDataExists(jobApplicationData.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jobApplicationData);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.JobApplications == null)
            {
                return NotFound();
            }

            var jobApplicationData = await _context.JobApplications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobApplicationData == null)
            {
                return NotFound();
            }

            return View(jobApplicationData);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.JobApplications == null)
            {
                return Problem("Entity set 'JobApplicationDBContext.JobApplications'  is null.");
            }
            var jobApplicationData = await _context.JobApplications.FindAsync(id);
            if (jobApplicationData != null)
            {
                _context.JobApplications.Remove(jobApplicationData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool JobApplicationDataExists(int id)
        {
            return (_context.JobApplications?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
