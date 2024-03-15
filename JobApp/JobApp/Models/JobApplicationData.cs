using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
namespace JobApp.Models
{

    [Table("JobApplicationData")]
    public class JobApplicationDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Contact is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Contact { get; set; }

        public string PreferredLocation { get; set; }
        public decimal ExpectedCTC { get; set; }
        public decimal CurrentCTC { get; set; }
        public int NoticePeriod { get; set; }

        public string Ccharpexperience { get; set; }
        public string Mssqlexperience { get; set; }
        public string dotnetexperience { get; set; }
        public string devopsexperience { get; set; }
    }

    public class JobApplicationData
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Contact is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Contact { get; set; }

        public List<Education> Educations { get; set; }


        public List<WorkExperience> WorkExperiences { get; set; }

        public string PreferredLocation { get; set; }
        public decimal ExpectedCTC { get; set; }
        public decimal CurrentCTC { get; set; }
        public int NoticePeriod { get; set; }

        public string Ccharpexperience { get; set; }
        public string Mssqlexperience { get; set; }
        public string dotnetexperience { get; set; }
        public string devopsexperience { get; set; }
    }
    [Table("Education")]
    public class Education
    {
        [Key]
        public int Id { get; set; }

        public string Qualification { get; set; }
        [Required(ErrorMessage = "Board/University is required")]
        public string BoardUniversity { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        [Required(ErrorMessage = "CGPA/Percentage is required")]
        public double CGPA { get; set; }
        public int JobApplicationId { get; set; }


    }
    [Table("WorkExperience")]
    public class WorkExperience
    {
        [Key]
        public int Id { get; set; }
        public string Company { get; set; }
        public string Designation { get; set; }
        public DateTime Fromdate { get; set; }
        public DateTime Todate { get; set; }
        public int JobApplicationId { get; set; }



    }


}

