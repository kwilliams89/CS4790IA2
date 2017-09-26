using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS4790IA2.Models
{

        [Table("Section")]
        public class Section
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [Range(1, int.MaxValue)]
            public int SectionID { get; set; }

            [Required]
            [Range(1, int.MaxValue)]
            public int SectionNumber { get; set; }

            [Required]
            [StringLength(10, ErrorMessage = "Course number must be 10 characters or less.")]
            public string CourseNumber { get; set; }

            [Required]
            [StringLength(10, ErrorMessage = "Section days must be 10 characters or less.")]
            public string SectionDays { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public string SectionTime { get; set; }

        }

        [Table("Course")]
        public class Course
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [StringLength(10, ErrorMessage = "Course number must be 50 characters or less.")]
            public string CourseNumber { get; set; }

            [Required]
            [StringLength(50, ErrorMessage = "Course name must be 50 characters or less.")]
            public string CourseName { get; set; }

            [Required]
            [Range(1, int.MaxValue)]
            public int CreditHours { get; set; }

            [Range(1, int.MaxValue)]
            public int? MaxEnrollment { get; set; }

        }

        public class BasicSchoolDbContext : DbContext
        {
            public DbSet<Course> Courses { get; set; }
            public DbSet<Section> Sections { get; set; }
        }


    public class BasicSchool
    {
        public static CourseSection getCourseAndSections(int? id)
        {
            BasicSchoolDbContext db = new BasicStudentDbContext();
            CourseSection courseSection = new CourseSection();

            var sections = db.sections.Where(s => s.courseNumber == courseSection.course.courseNumber);
            courseSection.sections = sections.ToList();

            return courseSection;
        }
    }
}
