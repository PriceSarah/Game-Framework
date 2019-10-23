using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Framework
{
    enum Direction
    {
        North,
        East,
        South,
        West
    }
    class Room : Scene
    {
        //rooms connected to this one
        private Room _north;
        private Room _south;
        private Room _east;
        private Room _west;

        public Room() : this(30, 25)
        {

        }

        public Room(int sizeX, int sizeY) : base(sizeX, sizeY)
        {

        }

        public Room North
        {
            get
            {
                return _north;
            }
            set
            {

                //connect the room both ways
                if (value != null)
                {
                    value._south = this;
                }
                /*
                //If we are clearing
                else
                {
                    _north._south = null;
                }
                */
                _north = value;
            }
        }

        public Room East
        {
            get
            {
                return _east;
            }
            set
            {
                if (value != null)
                {
                    value._west = this;
                }
                _east = value;
            }
        }

        public Room South
        {
            get
            {
                return _south;
            }
            set
            {
                if (value != null)
                {
                    value._north = this;
                }
                _south = value;
            }
        }

        public Room West
        {
            get
            {
                return _west;
            }
            set
            {
                if (value != null)
                {
                    value._east = this;
                }
                _west = value;
            }
        }
    }
}
