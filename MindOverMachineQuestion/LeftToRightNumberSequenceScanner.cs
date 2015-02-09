using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindOverMachineQuestion
{
    public class LeftToRightNumberSequenceScanner : NumberSequenceScanner
    {
        private const int NUMBERTOSKPISCAN = 3;
        public override List<ProductComponent> GetScannedNumberSequence()
        {
            StringBuilder itemBuilder = new StringBuilder();
            Dictionary<string, long> products = new Dictionary<string, long>();

            List<ProductComponent> Components = new List<ProductComponent>();

            Dictionary<string, long> scannedItemsWithMultipication = new Dictionary<string, long>();
            var currentData = base.OriginalDataIn2dArray;
            var totalRows = base.TotalRows;
            var totalColumns = base.TotalColumns;

            List<List<long>> itemsListFromLeftToRight = new List<List<long>>();

            for (var rowIndex = 0; rowIndex < totalRows; rowIndex++)
            {
                int scannedItemsCountLeftToRight = 0;
                for (var columnIndex = 0; columnIndex < totalColumns; columnIndex++)
                {
                    var currentIndexItem = currentData[rowIndex, columnIndex];

                    if (columnIndex + NUMBERTOSKPISCAN < totalRows
                        && scannedItemsCountLeftToRight < totalRows)
                    {

                        itemsListFromLeftToRight.Add(new List<long> {
                        
                            currentData[rowIndex, columnIndex],
                            currentData[rowIndex, columnIndex + 1],
                            currentData[rowIndex, columnIndex + 2],
                            currentData[rowIndex, columnIndex + 3]
                        
                        });
                        scannedItemsCountLeftToRight = scannedItemsCountLeftToRight + 1;
                    }
                }

                if (itemsListFromLeftToRight.Count > 0)
                {
                    for (var index = 0; index < itemsListFromLeftToRight.Count; index++)
                    {
                        Components.Add(base.GetComponent(itemsListFromLeftToRight[index]));
                    }

                }
            }

            return Components;
        }
    }
}