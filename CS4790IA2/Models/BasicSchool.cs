using System;
using System.Collections.Generic;
using System.Linq;
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
        public DateTime SectionTime { get; set; }

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
            courseSection.course = getCourse(id);

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

        public static void createCourse(Course course)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.Entry(course).State = EntityState.Added;
            db.Courses.Add(course);
            db.SaveChanges();
        }

        public static Course getCourse(int? id)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            return db.Courses.Find(id);
        }

        public static void editCourse(Course course)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.Entry(course).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void deleteSection(Section section)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.Entry(section).State = EntityState.Deleted;
            db.Sections.Remove(section);
            db.SaveChanges();
        }

        public static List<Section> getSections()
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            return db.Sections.ToList();
        }

        public static Section getSectionDetails(int? id)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            return db.Sections.Find(id);
        }

        public static void createSection(Section section)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.Entry(section).State = EntityState.Added;
            db.Sections.Add(section);
            db.SaveChanges();
        }

        public static Section getSection(int? id)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            return db.Sections.Find(id);
        }

        public static void editSection(Section section)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.Entry(section).State = EntityState.Modified;
            db.SaveChanges();
        }


    }
}
