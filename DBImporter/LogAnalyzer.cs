using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBImporter
{
    public class LogAnalyzer
    {
        public bool IsWorking = false;

        public int TableCount { get; private set; }
    
        public int Errors { get; private set; }

        public void Analyze(string log)
        {
            string[] arr = log.Split(new string[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length == 0)
                return;

            switch (arr[0])
            {
                case ("INF"):
                    {
                        switch (arr[3])
                        {
                            case ("Started"):
                                IsWorking = true;
                                break;
                            case ("Progress"):
                                {
                                    switch (arr[4])
                                    {
                                        case ("Finished"):
                                            IsWorking = false;
                                            break;
                                    }
                                 break;
                                }
                        }
                        switch (arr[2])
                        {
                            case ("TableName"):
                                TableCount++;
                                break;
                        }
                    }
                    break;

                case ("ERR"):
                    Errors++;
                        break;
            }           
        }
    }
}
