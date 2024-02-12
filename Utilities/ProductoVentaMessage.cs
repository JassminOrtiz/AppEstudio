using AppPruebaV1.DTOs;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPruebaV1.Utilities
{
    class ProductoVentaMessage : ValueChangedMessage<ProductoDTO>
    {
        public ProductoVentaMessage(ProductoDTO value) : base(value)
        {
        }
    }
}
