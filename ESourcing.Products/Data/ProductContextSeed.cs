using ESourcing.Products.Entities;
using MongoDB.Driver;

namespace ESourcing.Products.Data
{
    public class ProductContextSeed
    {
        public static void SeedData(IMongoCollection<Product> producCollection)
        {
            bool existProduct = producCollection.Find(p => true).Any();
            if(!existProduct)
            {
                producCollection.InsertManyAsync(GetConfigureProduct());
            }
        }

        private static IEnumerable<Product> GetConfigureProduct()
        {
            return new List<Product>()
            {
                new Product
                {
                    Name = "Huawei Plus",
                    Summary = "It is a wonderful phone...",
                    Description = "Lorem Ipsum is simply dummy text of the printing and " +
                    "typesetting industry. Lorem Ipsum has been the industry's standard dummy " +
                    "text ever since the 1500s, when an unknown printer took a galley of type and " +
                    "scrambled it to make a type specimen book. It has survived not only five centuries, " +
                    "but also the leap into electronic typesetting, remaining essentially unchanged. " +
                    "It was popularised in the 1960s with the release of Letraset sheets containing ",
                     Price = 2000.00M
                },
                new Product
                {
                    Name = "Huawei Minus",
                    Summary = "It is a wonderful phone...",
                    Description = "Lorem Ipsum is simply dummy text of the printing and " +
                    "typesetting industry. Lorem Ipsum has been the industry's standard dummy " +
                    "text ever since the 1500s, when an unknown printer took a galley of type and " +
                    "scrambled it to make a type specimen book. It has survived not only five centuries, " +
                    "but also the leap into electronic typesetting, remaining essentially unchanged. " +
                    "It was popularised in the 1960s with the release of Letraset sheets containing ",
                     Price = 1000.00M
                },
                new Product
                {
                    Name = "Xiaomi Plus",
                    Summary = "It is a wonderful phone...",
                    Description = "Lorem Ipsum is simply dummy text of the printing and " +
                    "typesetting industry. Lorem Ipsum has been the industry's standard dummy " +
                    "text ever since the 1500s, when an unknown printer took a galley of type and " +
                    "scrambled it to make a type specimen book. It has survived not only five centuries, " +
                    "but also the leap into electronic typesetting, remaining essentially unchanged. " +
                    "It was popularised in the 1960s with the release of Letraset sheets containing ",
                     Price = 2500.00M
                },
                new Product
                {
                    Name = "Xiaomi Minus",
                    Summary = "It is a wonderful phone...",
                    Description = "Lorem Ipsum is simply dummy text of the printing and " +
                    "typesetting industry. Lorem Ipsum has been the industry's standard dummy " +
                    "text ever since the 1500s, when an unknown printer took a galley of type and " +
                    "scrambled it to make a type specimen book. It has survived not only five centuries, " +
                    "but also the leap into electronic typesetting, remaining essentially unchanged. " +
                    "It was popularised in the 1960s with the release of Letraset sheets containing ",
                     Price = 1500.00M
                }
            };
        }
    }
}
