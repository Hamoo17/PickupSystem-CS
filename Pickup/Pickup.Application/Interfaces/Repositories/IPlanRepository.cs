﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Interfaces.Repositories
{
   public interface IPlanRepository
    {
        Task<bool> IsPlanExist(string PlanName , int PlanTypeId);
    }
}