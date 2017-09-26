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

        public class CourseSection
        {
            public CourseSection()
            {
            }

            public Course course { get; set; }
            public List<Section> sections { get; set; }
        }
    }
}
