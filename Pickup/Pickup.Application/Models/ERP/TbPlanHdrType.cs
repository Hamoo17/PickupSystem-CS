﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbPlanHdrType
    {
        public int Id { get; set; }
        public int PlanHdrId { get; set; }
        public int TypeId { get; set; }

        public virtual TbPlanMasterHdr PlanHdr { get; set; }
        public virtual TbMealsType Type { get; set; }
    }
}
