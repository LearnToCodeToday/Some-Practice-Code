using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindOverMachineQuestion
{
    public abstract class NumberSequenceScanner : INumberSequenceScanner
    {

        protected  long[,] OriginalDataIn2dArray { get { return DataHelper.GetDataPoints(); } }

        protected int TotalRows { get { return this.OriginalDataIn2dArray.GetLength(0); } }
        protected int TotalColumns {   get { return this.OriginalDataIn2dArray.GetLength(1); } }

        public abstract List<ProductComponent> GetScannedNumberSequence();


        protected ProductComponent GetComponent(List<long> list)
        {
            long product = 1;
            string productDescription = string.Empty;

            foreach (var itmeProduct in list)
            {
                product = product * itmeProduct;
                productDescription = productDescription + itmeProduct + "x";

            }
            return new  ProductComponent { Component = productDescription, Product = product };
        }

        protected List<ProductComponent> GetProduct(List<List<long>> productList)
        {

            /// make sure do input validation : skipped for now
            List<ProductComponent> Components = new List<ProductComponent>();
            if (productList.Count > 0)
            {
                for (var index = 0; index < productList.Count; index++)
                {
                    long product = 1;
                    string productDescription = string.Empty;

                    foreach (var itmeProduct in productList[index])
                    {
                        product = product * itmeProduct;
                        productDescription = productDescription + itmeProduct + "x";

                    }
                    Components.Add(new ProductComponent { Component = productDescription, Product = product });
                }

            }

            return Components;
        }
        
    }
}
