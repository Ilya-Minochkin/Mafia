using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Enums
{
    public class RolesEnum
    {
        public enum Role
        {
            Mafia = 1,
            Don = 2,
            Innocent = 0,
            Sheriff = 3,
            Host = -1
        }

    }
}
