using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Linq;

namespace LinqToSqlTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TekPubDataContext())
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Category>(c => c.Products);
                context.LoadOptions = loadOptions;
                
                foreach (Category category in context.Categories)
                {
                    Console.WriteLine(category.Name);
                    foreach (Product product in category.Products)
                    {
                        Console.WriteLine(product.Name);
                    }
                }

                context.SubmitChanges();
            }
        }
    }
}
