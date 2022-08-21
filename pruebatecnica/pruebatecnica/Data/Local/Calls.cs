using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using pruebatecnica.Models;

namespace pruebatecnica.Data.Local
{
    public class Calls
    {
        public Calls()
        {
        }

        public async Task SaveProducts(List<Root> rootlist)
        {
            foreach (var root in rootlist)
            {

            var rating = new Rating
            {
                count = root.rating.count,
                rate = root.rating.rate,
                id = root.id
            };

            var product = new Product
            {
                title = root.title,
                description = root.description,
                category = root.category,
                id = root.id,
                image = root.image,
                price = root.price,
                RatingId = rating.id
            };

            await App.Database.SaveRatingAsync(rating);
            await App.Database.SaveProductAsync(product);
            }
        }

        public async Task<List<Root>> GetPoductsList()
        {
            List<Root> productlistroot = new List<Root>();

            var products = await App.Database.GetProductsAsync();
            foreach (var item in products)
            {
                productlistroot.Add(new Root
                {
                    title = item.title,
                    description = item.description,
                    category = item.category,
                    id = item.id,
                    image = item.image,
                    price = item.price,
                    rating = await App.Database.GetRatingsAsync(item.id)

                }) ;

            }
            return productlistroot;
        }

        public async Task DeleteRegisters()
        {
            await App.Database.DeleteRegisters();
        }

    }
}

