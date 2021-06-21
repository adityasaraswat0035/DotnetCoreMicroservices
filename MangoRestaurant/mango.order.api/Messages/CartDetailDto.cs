﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.order.api.Messages
{
    public class CartDetailDto
    {
        public int Id { get; set; }
        public int CartHeaderId { get; set; }
        public CartHeaderDto CartHeader { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int Count { get; set; }
    }
}
