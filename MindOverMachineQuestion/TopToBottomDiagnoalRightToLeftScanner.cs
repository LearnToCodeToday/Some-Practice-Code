using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindOverMachineQuestion
{
    public class TopToBottomDiagnoalRightToLeftScanner : NumberSequenceScanner
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
                for (var columnIndex = totalColumns; columnIndex > 0; columnIndex--)
                {
                    if (columnIndex > 3 && rowIndex < 17)
                    {
                        itemsListFromTopToBottomDiagonal.Add(new List<long> {

                            currentData[rowIndex, columnIndex - 1],
                            currentData[rowIndex + 1, columnIndex - 2],
                            currentData[rowIndex + 2, columnIndex  - 3],
                            currentData[rowIndex + 3, columnIndex - 4]

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
