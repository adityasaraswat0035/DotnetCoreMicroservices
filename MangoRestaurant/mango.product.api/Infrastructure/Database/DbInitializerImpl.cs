using mango.product.contract.contracts;
using mango.product.repository.DbContexts;
using mango.product.repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.product.api.Infrastructure.Database
{
    public class DbInitializerImpl : DbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public DbInitializerImpl(IServiceScopeFactory scopeFactory)
        {
            this._scopeFactory = scopeFactory;
        }
        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ProductDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ProductDbContext>())
                {
                    if (!context.Categories.Any())
                    {
                        context.Categories.AddRange(
                            new Category()
                            {
                                Name = "Appetizer",
                                Products = new List<Product>()
                                {
                                    new Product()
                                    {
                                        Name="Samosa",
                                        Price=15,
                                        Description="Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                                        ImageUrl="samosa.jpeg"

                                    },
                                     new Product()
                                    {
                                        Name="Paneer Tikka",
                                        Price=13.99,
                                        Description="Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                                        ImageUrl="paneer_tikka.jpeg"

                                    }
                                }
                            },
                             new Category()
                             {
                                 Name = "Dessert",
                                 Products = new List<Product>()
                                {
                                    new Product()
                                    {
                                        Name="Sweet Pie",
                                        Price=10.99,
                                        Description="Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                                        ImageUrl="swwt_pie.jpeg"

                                    }
                                }
                             },
                              new Category()
                              {
                                  Name = "Entree",
                                  Products = new List<Product>()
                                {
                                    new Product()
                                    {
                                        Name="Pav Bhaji",
                                        Price=15,
                                        Description="Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                                        ImageUrl="pav_bhaji.jpeg"

                                    }
                                }
                              });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
