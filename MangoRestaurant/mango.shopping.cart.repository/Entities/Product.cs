using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Represent Product Entity in the Database
/// Info: for Simple Entity Lazy Loading read https://www.learnentityframeworkcore.com/lazy-loading
/// </summary>
namespace mango.shopping.cart.repository.Entities
{
    [Table(name: "Product", Schema = "dbo")]
    public class Product : BaseEntity<int>
    {
        /// <summary>
        /// Mandatory Product Name
        /// </summary>
        [Column(name: "Name")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Price of the product should be b/w 1$ and 1000$
        /// </summary>
        [Column(name: "Price")]
        [Range(1, 1000)]
        public double Price { get; set; }

        /// <summary>
        /// Details About the Product
        /// </summary>
        [Column("Description")]
        public string Description { get; set; }
        /// <summary>
        /// Url of Images Stored in Blob Storage (Azure or Other Databases or FTP Server or Static Folder) i.e Just the Image Name and Extension
        /// </summary>
        [Column("ImageUrl")]
        public string ImageUrl { get; set; }
    }
}
