﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbUnit
    {
        public TbUnit()
        {
            TbItems = new HashSet<TbItem>();
            TbMeals = new HashSet<TbMeal>();
        }

        public int Id { get; set; }
        public int? UnitId { get; set; }
        public string EnName { get; set; }
        public string Notes { get; set; }
        public int? ComId { get; set; }
        public int? UserId { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<TbItem> TbItems { get; set; }
        public virtual ICollection<TbMeal> TbMeals { get; set; }
    }
}
