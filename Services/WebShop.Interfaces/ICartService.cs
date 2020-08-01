﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.ViewModels;

namespace WebShop.Infrastructure.Interfaces
{
    public interface ICartService
    {
        void AddToCart(int id);

        void DecrementFromCart(int id);

        void RemoveFromCart(int id);

        void Clear();

        CartViewModel TransformFromCart();
    }
}
