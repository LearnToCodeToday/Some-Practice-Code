using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindOverMachineQuestion
{
    public class GreatestProductFinders
    {
        public ProductComponent GetProductComponent(List<ProductComponent> productComponents)
        {
            productComponents.Sort(delegate(ProductComponent x, ProductComponent y)
            {
                return y.Product.CompareTo(x.Product);
            });

            return productComponents[0];
        }
    }
}
