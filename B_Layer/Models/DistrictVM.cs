﻿using DAL_Layer.Entity;
using DAL_Layer.Entity.Place;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Layer.Models
{
    public class DistrictVM
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
