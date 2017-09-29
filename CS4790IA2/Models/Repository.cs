using System.Collections.Generic;


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

        public static void createCourse(Course course)
        {
            BasicSchool.createCourse(course);
        }

        public static void deleteCourse(Course course)
        {
            BasicSchool.deleteCourse(course);
        }

        public static Course getCourse(int? id)
        {
            return BasicSchool.getCourse(id);
        }

        public static void editCourse(Course course)
        {
            BasicSchool.editCourse(course);
        }

        public static List<Section> getSections()
        {
            return BasicSchool.getSections();
        }

        public static Section getSectionDetails(int? id)
        {
            return BasicSchool.getSectionDetails(id);
        }

        public static void createSection(Section section)
        {
            BasicSchool.createSection(section);
        }

        public static void deleteSection(Section section)
        {
            BasicSchool.deleteSection(section);
        }

        public static Section getSection(int? id)
        {
            return BasicSchool.getSection(id);
        }

        public static void editSection(Section section)
        {
            BasicSchool.editSection(section);
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
