﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Things
    {
        public string Wallet { get; set; }
        public string Keys { get; set; }
        public string CellPhone { get; set; }
        public string Watch { get; set; }

        //public List<string> Inventory { get; set; }

        //List<Things> myInventory = new List<Things>();

        public Things()
        {
            Wallet = "wallet";
            Keys = "keys";
            CellPhone = "cellPhone";
            Watch = "watch";
        }
        
    }
}
