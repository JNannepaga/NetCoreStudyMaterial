using EFCorePMC.DataAnnotation.OnetoManyMapping.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCorePMC.DataAnnotation.OnetoManyMapping
{
    public class OnetoManyImplementor
    {
        public static void Encounter()
        {
            Order o1 = new Order()
            {
                TaxAmount = 12,
                DeliveryCharge = 30
            };

            Customer c1 = new Customer()
            {
                FirstName = "Abhizzz",
                LastName = "Yanaz",
                Gender = Gender.Male,
                Orders = new List<Order>() { o1 }
            };

            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    //dbContext.Orders.Add(o1);

                    dbContext.Customers.Add(c1);
                    dbContext.SaveChanges();

                    List<Order> orders = dbContext.Orders.ToList<Order>();

                    orders.ForEach(x =>
                    {
                        Console.WriteLine($"OrderId : {x.OrderId} \nItemsCost : {x.ItemCost} \nTax : {x.TaxAmount} \nDelivery : {x.DeliveryCharge} \nTotal Pay : {x.TotalAmount}");
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
