using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindOverMachineQuestion
{
    class Program
    {
        
        static void Main(string[] args)
        {

            findTheGreatestNeighbouringSequenceInEntireNumberListing();

            //writeRecordsInFilesReview();
        }


        private static string getSortedResults(List<ProductComponent> products)
        {
            StringBuilder itemBuilder = new StringBuilder();
            products.Sort(delegate(ProductComponent x, ProductComponent y)
            {
                return y.Product.CompareTo(x.Product);
            });

            foreach (var product in products)
            {
                itemBuilder.AppendLine("[" + product.Component + "]  = " + product.Product);

            }
            return itemBuilder.ToString();
        }

        private static void findTheGreatestNeighbouringSequenceInEntireNumberListing()
        {
            NumberSequenceScanner scanner = new TopToBottomNumberSequenceScanner();
            List<string> greatestNeighboringSequence = new List<string>();
            var itemsScannedFromTopToBottom = scanner.GetScannedNumberSequence();
            scanner = new LeftToRightNumberSequenceScanner();
            var itemsScannedFromLeftToRight = scanner.GetScannedNumberSequence();
            scanner = new TopToBottmonDiagnoalLeftToRightScanner();

            var itemsScannedDiagonalFromLeftToRight = scanner.GetScannedNumberSequence();

            scanner = new TopToBottomDiagnoalRightToLeftScanner();

            var itemScannedDiagonalFromRightToLeft = scanner.GetScannedNumberSequence();

            var greatestProductFinder = new GreatestProductFinders();

            var itemsScannedFromTopToBottomHighest = greatestProductFinder.GetProductComponent(itemsScannedFromTopToBottom);
            var itemsScannedFromLeftToRightHighest = greatestProductFinder.GetProductComponent(itemsScannedFromLeftToRight);
            var itemsScannedDiagonalFromLeftToRightHighest = greatestProductFinder.GetProductComponent(itemsScannedDiagonalFromLeftToRight);
            var itemScannedDiagonalFromRightToLeftHighest = greatestProductFinder.GetProductComponent(itemScannedDiagonalFromRightToLeft);


            List<ProductComponent> components = new List<ProductComponent>();

            components.Add(itemsScannedFromTopToBottomHighest);
            components.Add(itemsScannedFromLeftToRightHighest);
            components.Add(itemsScannedDiagonalFromLeftToRightHighest);
            components.Add(itemScannedDiagonalFromRightToLeftHighest);



            // sort it

            components.Sort((x, y) => { return y.Product.CompareTo(x.Product); });

            // print on console

            //foreach (var component in components)
            //{

            //    Console.WriteLine("Higest Components from different types of scanner : " + component.Component + " Product : =" + component.Product);
            //}



            var highestComponent = greatestProductFinder.GetProductComponent(components);


            Console.WriteLine("Highest Neighbouring sequence number is : ");
            Console.WriteLine("[" + highestComponent.Component.Substring(0, highestComponent.Component.Length - 1) + "]=" + highestComponent.Product);

            Console.ReadLine();

        }

        private static void writeRecordsInFilesReview()
        {
            NumberSequenceScanner scanner = new TopToBottomNumberSequenceScanner();

            List<string> greatestNeighboringSequence = new List<string>();
            var currentData = DataHelper.GetDataPoints();
            var itemsScannedFromTopToBottom = scanner.GetScannedNumberSequence();
            string topToBottom = getSortedResults(itemsScannedFromTopToBottom);


            scanner = new LeftToRightNumberSequenceScanner();
            var itemsScannedFromLeftToRight = scanner.GetScannedNumberSequence();
            string leftToRight = getSortedResults(itemsScannedFromLeftToRight);

            scanner = new TopToBottmonDiagnoalLeftToRightScanner();

            var itemsScannedDiagonalFromLeftToRight = scanner.GetScannedNumberSequence();

            string topToBottomDiagonal = getSortedResults(itemsScannedDiagonalFromLeftToRight);


            scanner = new TopToBottomDiagnoalRightToLeftScanner();

            var itemScannedDiagonalFromRightToLeft = scanner.GetScannedNumberSequence();

            string topToBottomDiagonalGoingRightToLeft = getSortedResults(itemScannedDiagonalFromRightToLeft);


            print(topToBottom, leftToRight, topToBottomDiagonal, topToBottomDiagonalGoingRightToLeft);
        }

        private static void print(string topToBottom, string leftToRight, string topToBottomDiagonal, string topToBottomDiagonalGoingRightToLeft)
        {
            string results = "Results from scanning from left to right\r\n\n";
            results = results + "______________________________________\r\n\n";
            results = results + leftToRight;
            results = results + "Results from scanning from top to bottom\r\n\n\n";
            results = results + topToBottom;

            results = results + "Results from scanning from top to bottom Diagonal going left to right\r\n\n\n";
            results = results + topToBottomDiagonal;
            results = results + "Results from scanning from top to bottom Diagonal going right to left\r\n\n\n";
            results = results + topToBottomDiagonalGoingRightToLeft;

            string fileLocation = @"C://2015/Data/data.txt";
            MultipicationDataWriter.WriteToFile(fileLocation, results);
        }

        private static void print(List<List<long>> itemsListFromLeftToRight)
        {
            if (itemsListFromLeftToRight != null && itemsListFromLeftToRight.Count > 0)
            {

                foreach (var listItem in itemsListFromLeftToRight)
                {

                    foreach (var innerItem in listItem)
                    {
                        Console.Write(innerItem + "  ");
                    }

                    Console.WriteLine();
                }
            }
        }

        private static void someTesting(long[,] currentData)
        {
            var itemOne = currentData[7, 5];
            var itemTow = currentData[8, 6];

            var itemThree = currentData[9, 7];

            var itemFour = currentData[10, 8];


            Console.WriteLine(itemOne * itemTow * itemThree * itemFour);

            Console.ReadLine();
        }
    }
}
