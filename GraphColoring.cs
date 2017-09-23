using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApplication
{
    class GraphColoring
    {
        //
        private DataTable roomData;
        private DataTable courseResults;
        
        private List<Course> vertices;
        private List<string> colors;
        private int[,] matrix;
        
        public GraphColoring(DataTable roomList, DataTable courseResults)
        {
            roomData = roomList;
            this.courseResults = courseResults;
            vertices = new List<Course>();
          //  this.addVerticesFromData();
           // matrix = new int[vertices.Count, vertices.Count];
            
        }
        
        private void addVerticesFromData()
        {
            Boolean duplicated;
            for (int i = 1; i < courseResults.Rows.Count; i++)
            {
                duplicated = false;
                for(int j = 0; j < vertices.Count; j++)
                {
                    if (courseResults.Rows[i].Field<int>(0).Equals(vertices[j].getCourseCode()))
                    {
                        duplicated = true;
                        break;
                    }       
                }
                if (duplicated == false)
                {
                    int courseCode = courseResults.Rows[i].Field<int>(0);
                    int groupNo = courseResults.Rows[i].Field<int>(2);
                    vertices.Add(new Course(courseCode, groupNo));
                }
            }
        }
        public void setRoomList(DataTable d)
        {
            roomData = d;
        }
        
        public void setCourseResults(DataTable d)
        {
            courseResults = d;
        }
        public DataTable getCourseResults()
        {
            return courseResults;
        }
        public DataTable getShedule()
        {
            //to-do work
            return null;
        }

    }
}
