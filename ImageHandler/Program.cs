using ImageHandler.Data;
using ImageHandler.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Nasse
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ImageDbContext context = new ImageContextFactory().CreateDbContext();
            // Let's begin a transaction. All DB change from here until Commit
            // are either completely written or not written at all (rollback).
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                Image test = new Image
                {
                    Name = "Test2",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Metadata = new MetaData
                    {
                        Size = new Sizes()
                        {
                            Height = 200,
                            Width = 200,
                        }
                    }
                };
                context.Images.Add(test);
                context.SaveChanges();
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Something bad happened: {ex.Message}");
            }

            using (context)
            {
                var list = context.Images.Include(a => a.Metadata).ToList();

                foreach (var image in list)
                {
                    Console.WriteLine(image.Name + " " + image.CreatedDate);
                }
            }
        }
    }
}
