using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

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
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            CourseSection courseSection = new CourseSection();

            var sections = db.Sections.Where(s => s.CourseNumber == courseSection.course.CourseNumber);
            courseSection.sections = sections.ToList();

            return courseSection;
        }

        public static void deleteCourse(Course course)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.Entry(course).State = EntityState.Deleted;
            db.Courses.Remove(course);
            db.SaveChanges();

        }

        public static List<Course> getCourses()
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            return db.Courses.ToList();
        }

        public static Course getCourseDetails(int? id)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            return db.Courses.Find(id);
        }


    }
}
