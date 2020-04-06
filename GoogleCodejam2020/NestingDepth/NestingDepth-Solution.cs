//using System;
//using System.Collections;
//using System.IO;
//using System.Linq;
//using System.Text;

//namespace GoogleCodejam2020
//{
//    public class Solution
//    {
//        static void Main(string[] args)
//        {
//            NestringDepgthStarterFileRead(args[0]);
//        }

//        private static void NestringDepgthStarterFileRead(string fileRelativePath)
//        {
//            String line;
//            int noOfTestCases;


//            //Pass the file path and file name to the StreamReader constructor
//            StreamReader streamReader = new StreamReader(fileRelativePath);

//            //Read the first line of text
//            line = streamReader.ReadLine().Trim();
//            noOfTestCases = Convert.ToInt32(line);

//            if (noOfTestCases <= 0)
//            {
//                return;
//            }

//            //Continue to read until you reach end of file  
//            int testCaseNo = 1;
//            while (line != null)
//            {
//                //Read the next line
//                line = streamReader.ReadLine();
//                if (!string.IsNullOrWhiteSpace(line))
//                {
//                    var outputString = GetOutputString(line);

//                    Console.WriteLine("Case #" + testCaseNo + ": " + outputString);
//                }

//                // let's move to test next test case
//                testCaseNo++;
//            }
//        }
//        private static void NestringDepgthStarterConsole()
//        {
//            String line;
//            int noOfTestCases;

//            //Read the first line of text
//            line = Console.ReadLine();
//            noOfTestCases = Convert.ToInt32(line);

//            if (noOfTestCases <= 0)
//            {
//                return;
//            }

//            //Continue to read until you reach end of file  
//            int testCaseNo = 1;
//            while (line != null)
//            {
//                //Read the next line
//                line = Console.ReadLine(); // streamReader.ReadLine();
//                if (!string.IsNullOrWhiteSpace(line))
//                {
//                    var outputString = GetOutputString(line);

//                    Console.WriteLine("Case #" + testCaseNo + ": " + outputString);
//                }

//                // let's move to test next test case
//                testCaseNo++;
//            }
//        }

//        private static string GetOutputString(string inputString)
//        {
//            int[] intArray = inputString.ToCharArray().Select(x => Convert.ToInt32(x.ToString())).ToArray();

//            StringBuilder returnValue = new StringBuilder();

//            // keep track of insert 
//            //      Opening bracket
//            //      Closing bracket
//            int openingCount = 0;
//            int closingCount = 0;
//            Queue queue = new Queue();


//            // let's start with "("
//            int previousInt = 0;

//            foreach (var c in intArray)
//            {
//                if (c == previousInt)
//                {
//                    queue.Enqueue(c);
//                }
//                else if (c < previousInt)
//                {
//                    // for closing bracket
//                    int diff = previousInt - c;
//                    for (int i = 0; i < diff; i++)
//                    {
//                        queue.Enqueue(")");
//                        closingCount++;
//                    }
//                    queue.Enqueue(c);
//                }
//                else
//                {
//                    // for opening bracket
//                    int diff = c - previousInt;
//                    for (int i = 0; i < diff; i++)
//                    {
//                        queue.Enqueue("(");
//                        openingCount++;
//                    }
//                    queue.Enqueue(c);
//                }

//                // change previous char
//                previousInt = c;
//            }

//            // 
//            if (closingCount < openingCount)
//            {
//                // add more closing count
//                int diff = openingCount - closingCount;
//                for (int i = 0; i < diff; i++)
//                {
//                    queue.Enqueue(")");
//                    closingCount++;
//                }
//            }

//            var queueEnumerator = queue.GetEnumerator();
//            while (queueEnumerator.MoveNext())
//            {
//                returnValue.Append(queueEnumerator.Current.ToString());
//            }



//            return returnValue.ToString();
//        }

//    }
//}