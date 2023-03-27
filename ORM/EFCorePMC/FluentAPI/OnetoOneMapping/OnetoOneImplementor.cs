using EFCorePMC.DataAnnotation.OnetoOneMapping;
using EFCorePMC.FluentAPI.OnetoOneMapping.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EFCorePMC.FluentAPI.OnetoOneMapping
{
    public class OnetoOneImplementor
    {
        public static void Encounter()
        {
            Customer c1 = new Customer()
            {
                FirstName = "Shreya",
                LastName = "Nans",
                Gender = Gender.Female,
                CustomerRequisites = new CustomerRequisite("9676518138", IdProofType.PANCard, "AQXPN5630N")
            };

            //Customer c2 = new GeneralCustomer()
            //{
            //    FirstName = "Shreya",
            //    LastName = "Nans",
            //    Gender = Gender.Female,
            //    Credits = 10,
            //    NormalCoupon = "Order 40",
            //    CustomerRequisites = new CustomerRequisite("9676518138", IdProofType.AadharCard, "2567810986")
            //};

            ValidationContext validationContext_c1 = new ValidationContext(c1);
            //ValidationContext validationContext_c2 = new ValidationContext(c2);

            List<ValidationResult> validationResults = new List<ValidationResult>();
            if (Validator.TryValidateObject(c1, validationContext_c1, validationResults, true)
                )//&& Validator.TryValidateObject(c2, validationContext_c2, validationResults, true))
            {
                using (FAPIOnetoOneDbContext dbContext = new FAPIOnetoOneDbContext())
                {
                    dbContext.Customers.Add(c1);
                    //dbContext.GeneralCustomers.Add(c2);
                    dbContext.SaveChanges();

                    List<Customer> regularCustomers = dbContext.Customers
                                                        .Include(c => c.CustomerRequisites)
                                                        //.OfType<RegularCustomer>()
                                                        .ToList();

                    //List<GeneralCustomer> generalCustomers = dbContext.GeneralCustomers
                    //                                    .Include(c => c.CustomerRequisites)
                    //                                    //.OfType<GeneralCustomer>()
                    //                                    .ToList();

                    regularCustomers.ForEach(customer =>
                    {
                        Console.WriteLine(
                       $"Customer Details:: {customer.CustomerId} \nName : {customer.FullName} \nGender : {customer.Gender} " +
                       $"\nMobile : {customer.CustomerRequisites?.Mobile} \n{customer.CustomerRequisites?.IdProofType} : {customer.CustomerRequisites?.IdProof}" //+
                       );//$"\nCredits : {customer.AdvCredits} \nPerks : {customer.Perks}"); 
                    });

                    //generalCustomers.ForEach(customer =>
                    //{
                    //    Console.WriteLine(
                    //    $"Customer Details:: {customer.CustomerId} \nName : {customer.FullName} \nGender : {customer.Gender} " +
                    //    $"\nMobile : {customer.CustomerRequisites?.Mobile} \n{customer.CustomerRequisites?.IdProofType} : {customer.CustomerRequisites?.IdProof}" +
                    //    $"\nCredits : {customer.Credits} \nPerks : {customer.NormalCoupon}\n\n");
                    //});

                }
            }
            else
            {
                foreach (ValidationResult result in validationResults)
                {
                    Console.WriteLine($"error Msg: {result.ToString()}");
                }
            }
        }
    }
}
