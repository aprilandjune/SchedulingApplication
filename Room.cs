using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApplication
{
    class Room
    {
        private int roomID;//0
        private int capacity;//1
        private string type;//2
        private string note;//3
        public Room(int roomID, int capacity, string type, string note)
        {
            
            this.roomID = roomID;
            this.capacity = capacity;
            this.type = type;
            this.note = note;
        }
        public Room(int roomID, int capacity, string type)
        {
            this.roomID = roomID;
            this.capacity = capacity;
            this.type = type;
            note = "";
        }
        public int getRoomID()
        {
            return roomID;
        }
        public int getCapacity()
        {
            return capacity;
        }

        public string getType()
        {
            return type;
        }
        public string getNote()
        {
            return note;
        }

    }
}
