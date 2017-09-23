using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApplication
{
    class Course
    {
        private int courseCode;//0
        private int groupNo;//2
        private int labGroupNo;//3
        private List<int> studentList;//5
        public int CourseCode { get; set; }

        public Course(int courseCode, int groupNo, int labGroupNo)
        {
            this.courseCode = courseCode;
            this.groupNo = groupNo;
            this.labGroupNo = labGroupNo;
            studentList = new List<int>();
        }
        public Course(int courseCode, int groupNo)
        {
            this.courseCode = courseCode;
            this.groupNo = groupNo;
            this.labGroupNo = 0;
            studentList = new List<int>();
        }
        public int getCourseCode()
        {
            return courseCode;
        }
        public int getGroupNo()
        {
            return groupNo;
        }
        public int getLabGroupNo()
        {
            return labGroupNo;
        }
    }
}
