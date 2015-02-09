using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindOverMachineQuestion
{
    public class TopToBottmonDiagnoalLeftToRightScanner : NumberSequenceScanner
    {
        public override List<ProductComponent> GetScannedNumberSequence()
        {
            StringBuilder itemBuilder = new StringBuilder();
            Dictionary<string, long> products = new Dictionary<string, long>();
            List<ProductComponent> Components = new List<ProductComponent>();


            Dictionary<string, long> scannedItemsWithMultipication = new Dictionary<string, long>();
            var currentData = base.OriginalDataIn2dArray;
            var totalRows = base.TotalRows;
            var totalColumns = base.TotalColumns;
            List<List<long>> itemsListFromTopToBottomDiagonal = new List<List<long>>();

            for (var rowIndex = 0; rowIndex < totalRows; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < totalColumns; columnIndex++)
                {
                    var currentIndexItem = currentData[rowIndex, columnIndex];
                    if (columnIndex + 3 < totalRows && rowIndex < 17)
                    {
                        itemsListFromTopToBottomDiagonal.Add(new List<long> {

                            currentData[rowIndex, columnIndex],
                            currentData[rowIndex + 1, columnIndex + 1],
                            currentData[rowIndex + 2, columnIndex  + 2],
                            currentData[rowIndex + 3, columnIndex + 3]

                        });
                    }

                }


                if (itemsListFromTopToBottomDiagonal.Count > 0)
                {
                    for (var index = 0; index < itemsListFromTopToBottomDiagonal.Count; index++)
                    {
                        Components.Add(base.GetComponent(itemsListFromTopToBottomDiagonal[index]));
                    }
                }

            }

            return Components;
        }
    }
}
