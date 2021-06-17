﻿using mango.product.repository.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Represent Product Entity in the Database
/// </summary>
namespace mango.product.repository.Entities
{
    [Table(name: "Product", Schema = "dbo")]
    public class Product: BaseEntity<int>
    {
        /// <summary>
        /// Mandatory Product Name
        /// </summary>
        [Column(name: "Name")]
        [Required]
        public String Name { get; set; }

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
        public String Descritpion { get; set; }
        /// <summary>
        /// Url of Images Stored in Blob Storage (Azure or Other Databases or FTP Server or Static Folder)
        /// </summary>
        [Column("ImageUrl")]
        public String ImageUrl { get; set; }

        /// <summary>
        /// Foreign Key Column Category
        /// </summary>
        [Column("CategoryId")]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        /// <summary>
        /// Category to Product Mapping
        /// </summary>
        public Category Category { get; set; }
    }
}
