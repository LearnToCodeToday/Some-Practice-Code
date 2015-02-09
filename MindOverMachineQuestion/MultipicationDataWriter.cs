using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindOverMachineQuestion
{
    public static class MultipicationDataWriter
    {
        public static void WriteToFile(string fileLocation, string content)
        {
            try
            {
                File.WriteAllText(fileLocation, content);
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
