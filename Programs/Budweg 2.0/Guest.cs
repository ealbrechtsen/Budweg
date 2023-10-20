﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budweg_2._0
{
    public class Guest
    {
        // properties til at gemme oplysninger om gæsten
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsCheckedIn { get; set; }

        public Guest(string name, int id)
        {
            Name = name;
            Id = id;
            IsCheckedIn = false;
        }

    }
}
