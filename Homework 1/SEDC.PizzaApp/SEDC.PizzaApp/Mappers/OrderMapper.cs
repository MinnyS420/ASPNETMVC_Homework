﻿using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel ToOrderViewModel(Order order) 
        {
            return new OrderViewModel()
            {
                PizzaName = order.Pizza.Name,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                UserAdress = order.User.UserAdress,
                PaymentMethod = order.PaymentMethod,
                Price = (int)(order.Pizza.Price + 50)
            };
        }

        public static OrderViewModel ToOrderViewModelExtension(this Order order)
        {
            return new OrderViewModel()
            {
                PizzaName = order.Pizza.Name,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                UserAdress = order.User.UserAdress,
                PaymentMethod = order.PaymentMethod,
                Price = (int)(order.Pizza.Price + 50)
            };
        }
    }
}
