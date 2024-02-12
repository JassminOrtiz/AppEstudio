using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPruebaV1.Utilities
{
    class ProductoMessage : ValueChangedMessage<ProductoResult>
    {
        public ProductoMessage(ProductoResult value) : base(value)
        {

        }
    }
}
