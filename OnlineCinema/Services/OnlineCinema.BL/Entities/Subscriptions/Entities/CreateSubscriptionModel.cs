﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Subscription.Entities;

public class CreateSubscriptionModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
