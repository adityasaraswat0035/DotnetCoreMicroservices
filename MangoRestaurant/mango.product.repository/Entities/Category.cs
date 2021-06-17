using mango.product.repository.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.product.repository.Entities
{
    /// <summary>
    /// Represent Product Category in Database
    /// </summary>
    [Table(name: "ProductCategory", Schema = "dbo")]
    public class Category:BaseEntity<int>
    {
        /// <summary>
        /// /// <summary>
        /// Mandatory Category Name
        /// </summary>
        /// </summary>
        [Column(name: "Name")]
        [Required]
        public String Name { get; set; }
        /// <summary>
        /// Mapping for Products To Category
        /// </summary>
        [InverseProperty(nameof(Product.Category))]
        public ICollection<Product> Products { get; set; }
    }
}
