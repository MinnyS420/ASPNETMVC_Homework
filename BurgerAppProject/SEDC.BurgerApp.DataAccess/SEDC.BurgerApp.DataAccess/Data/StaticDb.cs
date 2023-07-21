using SEDC.BurgerApp.Domain.Models;
using System;

namespace SEDC.BurgerApp.DataAccess.Data
{
    public static class StaticDb
    {
        public static int BurgerId { get; set; }
        public static int OrderId { get; set; }
        public static int LocationId { get; set; }
        public static List<Burger> Burgers { get; set; }
        public static List<Order> Orders { get; set; }
        public static List<Location>? Locations { get; set; }

        static StaticDb()
        {
            BurgerId = 10;
            OrderId = 4;
            LocationId = 3;

            Burgers = new List<Burger>
            {
                new Burger
                {
                    Id = 1,
                    Name = "Chicken Burger",
                    Price = 2,
                    IsVegan = false,
                    IsVegetarian = false,
                    IsPopularBurger = true,
                    HasFries = false,
                    BurgerOrders = new List<BurgerOrder> {}
                },
                new Burger
                {
                    Id = 2,
                    Name = "Ham Burger",
                    Price = 3,
                    IsVegan = false,
                    IsVegetarian = false,
                    IsPopularBurger = true,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> {}
                },
                new Burger
                {
                    Id = 3,
                    Name = "Veggie Burger",
                    Price = 2,
                    IsVegan = false,
                    IsVegetarian = true,
                    IsPopularBurger = false,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> {}
                },
                // Additional burgers
                new Burger
                {
                    Id = 4,
                    Name = "Cheeseburger",
                    Price = 3.5,
                    IsVegan = false,
                    IsVegetarian = false,
                    IsPopularBurger = true,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> {}
                },
                new Burger
                {
                    Id = 5,
                    Name = "Double Cheeseburger",
                    Price = 5.0,
                    IsVegan = false,
                    IsVegetarian = false,
                    IsPopularBurger = true,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> {}
                },
                new Burger
                {
                    Id = 6,
                    Name = "Bacon Burger",
                    Price = 4.5,
                    IsVegan = false,
                    IsVegetarian = false,
                    IsPopularBurger = true,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> {}
                },
                new Burger
                {
                    Id = 7,
                    Name = "Fish Burger",
                    Price = 3.8,
                    IsVegan = false,
                    IsVegetarian = false,
                    IsPopularBurger = false,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> {}
                },
                new Burger
                {
                    Id = 8,
                    Name = "Mushroom Burger",
                    Price = 3.2,
                    IsVegan = true,
                    IsVegetarian = true,
                    IsPopularBurger = true,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> {}
                },
                new Burger
                {
                    Id = 9,
                    Name = "BBQ Burger",
                    Price = 4.0,
                    IsVegan = false,
                    IsVegetarian = false,
                    IsPopularBurger = true,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> {}
                },
                new Burger
                {
                    Id = 10,
                    Name = "Vegan Burger",
                    Price = 3.5,
                    IsVegan = true,
                    IsVegetarian = true,
                    IsPopularBurger = true,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> {}
                }
            };

            Locations = new List<Location>
            {
                new Location
                {
                    Id = 1,
                    Name = "Tehno Burgeri",
                    Address = "Skopje",
                    OpensAt = new TimeSpan(07,00,00),
                    ClosesAt = new TimeSpan(22,00,00),
                },
                new Location
                {
                    Id = 2,
                    Name = "Anhoch Burgeri",
                    Address = "Bitola",
                    OpensAt = new TimeSpan(07,00,00),
                    ClosesAt = new TimeSpan(22,00,00),
                },
                new Location
                {
                    Id = 3,
                    Name = "Setek Burgeri",
                    Address = "Veles",
                    OpensAt = new TimeSpan(07,00,00),
                    ClosesAt = new TimeSpan(22,00,00),
                },
            };

            Orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    FullName = "Bob Bobsky",
                    Address = "Tehno Burgeri",
                    IsDelivered = true,
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 1,
                            Burger = Burgers[0],
                            BurgerId = Burgers[0].Id,
                            OrderId = 1,
                        },
                        new BurgerOrder
                        {
                            Id = 2,
                            Burger = Burgers[1],
                            BurgerId = Burgers[1].Id,
                            OrderId = 1,
                        }
                    },
                    Location = Locations[0]
                },
                new Order
                {
                    Id = 2,
                    FullName = "Boki Boksan",
                    Address = "Anhoch Burgeri",
                    IsDelivered = false,
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 3,
                            Burger = Burgers[2],
                            BurgerId = Burgers[2].Id,
                            OrderId = 2,
                        },
                    },
                    Location = Locations[1]
                },
                new Order
                {
                    Id = 3,
                    FullName = "Jhon Wick",
                    Address = "Setek Burgeri",
                    IsDelivered = false,
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 4,
                            Burger = Burgers[1],
                            BurgerId = Burgers[1].Id,
                            OrderId = 3,
                        },
                    },
                    Location = Locations[2]
                },
                // Additional orders
                new Order
                {
                    Id = 4,
                    FullName = "Jane Doe",
                    Address = "Anhoch Burgeri",
                    IsDelivered = false,
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 5,
                            Burger = Burgers[3],
                            BurgerId = Burgers[3].Id,
                            OrderId = 4,
                        },
                    },
                    Location = Locations[1]
                },
                new Order
                {
                    Id = 5,
                    FullName = "Peter Parker",
                    Address = "Tehno Burgeri",
                    IsDelivered = true,
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 6,
                            Burger = Burgers[4],
                            BurgerId = Burgers[4].Id,
                            OrderId = 5,
                        },
                        new BurgerOrder
                        {
                            Id = 7,
                            Burger = Burgers[5],
                            BurgerId = Burgers[5].Id,
                            OrderId = 5,
                        },
                    },
                    Location = Locations[0]
                },
                new Order
                {
                    Id = 6,
                    FullName = "Clark Kent",
                    Address = "Setek Burgeri",
                    IsDelivered = true,
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 8,
                            Burger = Burgers[6],
                            BurgerId = Burgers[6].Id,
                            OrderId = 6,
                        },
                    },
                    Location = Locations[2]
                },
                new Order
                {
                    Id = 7,
                    FullName = "Selina Kyle",
                    Address = "Anhoch Burgeri",
                    IsDelivered = false,
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 9,
                            Burger = Burgers[7],
                            BurgerId = Burgers[7].Id,
                            OrderId = 7,
                        },
                    },
                    Location = Locations[1]
                },
                new Order
                {
                    Id = 8,
                    FullName = "Bruce Wayne",
                    Address = "Tehno Burgeri",
                    IsDelivered = true,
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 10,
                            Burger = Burgers[8],
                            BurgerId = Burgers[8].Id,
                            OrderId = 8,
                        },
                    },
                    Location = Locations[0]
                },
                new Order
                {
                    Id = 9,
                    FullName = "Diana Prince",
                    Address = "Setek Burgeri",
                    IsDelivered = true,
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 11,
                            Burger = Burgers[9],
                            BurgerId = Burgers[9].Id,
                            OrderId = 9,
                        },
                    },
                    Location = Locations[2]
                },
                new Order
                {
                    Id = 10,
                    FullName = "Steve Rogers",
                    Address = "Anhoch Burgeri",
                    IsDelivered = false,
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 12,
                            Burger = Burgers[0],
                            BurgerId = Burgers[0].Id,
                            OrderId = 10,
                        },
                    },
                    Location = Locations[1]
                },
            };
        }
    }
}
