using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindOverMachineQuestion
{
    public class TopToBottomNumberSequenceScanner : NumberSequenceScanner
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
            List<List<long>> itemsListFromTopToBottom = new List<List<long>>();

            for (var rowIndex = 0; rowIndex < totalRows; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < totalColumns; columnIndex++)
                {
                    var currentIndexItem = currentData[rowIndex, columnIndex];

                   
                    if (rowIndex + 3 < totalRows)
                    {

                        itemsListFromTopToBottom.Add(new List<long> {

                                    currentData[rowIndex, columnIndex],
                                    currentData[rowIndex + 1, columnIndex],
                                    currentData[rowIndex + 2, columnIndex ],
                                    currentData[rowIndex + 3, columnIndex]

                                });
                    }

                }
                if (itemsListFromTopToBottom.Count > 0)
                {
                    for (var index = 0; index < itemsListFromTopToBottom.Count; index++)
                    {
                        Components.Add(base.GetComponent(itemsListFromTopToBottom[index]));
                    }
                }

            }
            return Components;
        }
    }
}
