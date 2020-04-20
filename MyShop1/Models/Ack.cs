﻿using MyShop.AUTH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop1.Models
{
    public class Ack<TData>
    {
        public TData Data { get; set; }

        public string Error { get; set; }

        public Ack(TData data, string error)
        {
            Data = data;
            Error = error;
        }

        public Ack(Response<TData> response)
        {
            Data = response.Data;
            Error = response.Error;
        }
    }
}
