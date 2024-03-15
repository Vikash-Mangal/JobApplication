using JobApp.Data;
using JobApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobApp.Controllers
{
    
    public class JobApplicationController : Controller
    {

        private readonly ApplicationDBContext _context;

        public JobApplicationController(ApplicationDBContext context)
        {
            _context = context;
        }
      
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobApplicationData jobApplicationData)
        {
            if (ModelState.IsValid)
            {
                JobApplicationDTO jobApplication = new JobApplicationDTO
                {
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
                _context.JobApplications.Add(jobApplication);
                await _context.SaveChangesAsync();

                foreach (var edu in jobApplicationData.Educations)
                {
                    edu.JobApplicationId = jobApplication.Id;
                    _context.Educations.Add(edu);
                    await _context.SaveChangesAsync();
                }
                foreach (var work in jobApplicationData.WorkExperiences)
                {
                    work.JobApplicationId = jobApplication.Id;
                    _context.WorkExperiences.Add(work);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(jobApplicationData);
        }

    }
}
