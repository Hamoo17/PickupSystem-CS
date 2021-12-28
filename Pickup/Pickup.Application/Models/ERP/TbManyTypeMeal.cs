﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbManyTypeMeal
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int MealId { get; set; }

        public virtual TbMeal Meal { get; set; }
        public virtual TbMealsType Type { get; set; }
    }
}
