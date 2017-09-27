using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS4790IA2.Models;

namespace CS4790IA2.Models
{
    public class Repository
    {
        public static CourseSection getCourseAndSections(int? id)
        {
            CourseSection courseSection = BasicSchool.getCourseAndSections(id);
            return courseSection;
        }

        public static List<Course> getCourses()
        {
            return BasicSchool.getCourses();
        }

        public static Course getCourseDetails(int? id)
        {
            return BasicSchool.getCourseDetails(id);
        }

        public static void deleteCourse(Course course)
        {
            BasicSchool.deleteCourse(course);
        }
    }

        public class CourseSection
        {
            public CourseSection()
            {
            }

            public Course course { get; set; }
            public List<Section> sections { get; set; }
        }

}
