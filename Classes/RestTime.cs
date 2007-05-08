using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public struct RestTime
    {
        public ushort field_0;
        public ushort field_2;
        public ushort field_4;
        public ushort field_6;
        public ushort field_8;
        public ushort field_A;
        public ushort field_C;

        public void Clear()
        {
            field_0 = 0;
            field_2 = 0;
            field_4 = 0;
            field_6 = 0;
            field_8 = 0;
            field_A = 0;
            field_C = 0;
        }

        public ushort this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return field_0;
                    case 1:
                        return field_2;
                    case 2:
                        return field_4;
                    case 3:
                        return field_6;
                    case 4:
                        return field_8;
                    case 5:
                        return field_A;
                    case 6:
                        return field_C;
                    default:
                        throw new NotSupportedException();
                }
            }
                       set
            {
                switch (index)
                {
                    case 0:
                        field_0 = value; break;
                    case 1:
                        field_2 = value; break;
                    case 2:
                        field_4 = value; break;
                    case 3:
                        field_6 = value; break;
                    case 4:
                        field_8 = value; break;
                    case 5:
                        field_A = value; break;
                    case 6:
                        field_C = value; break;
                    default:
                        throw new NotSupportedException();
                }
            }
        }
    }
}