﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Shop
{
    public static class Currency
    {
        public static string PriceWithCurrency(this double number, string currency)
        {
            return $"{number}" + currency;
        }
    }
}
