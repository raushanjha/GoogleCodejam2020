//using System;
//using System.IO;
//using System.Text;


//namespace GoogleCodejam2020
//{
//    public class Solution
//    {
//        static void Main(string[] args)
//        {
//            ParentingPartneringReturnsConsole();
//            //ParentingPartneringReturnsFromFile(args[0]);
//        }

//        private static void ParentingPartneringReturnsFromFile(string fileRelativePath)
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
//                    int noOfRows = Convert.ToInt32(line.Trim());

//                    // There will be always two columns (Start time, End time) + 1 (rowIndex)
//                    int[,] currentMatrix = GetCurrentInputMatrixFromStream(noOfRows, noOfColumns: 3, streamReader);

//                    var allocatedWork = SolveForMatrix(currentMatrix, noOfRows);

//                    Console.WriteLine("Case #" + testCaseNo + ": " + allocatedWork);

//                }

//                // let's move to test next test case
//                testCaseNo++;
//            }

//            //close the file
//            // streamReader.Close();
//        }

//        private static int[,] GetCurrentInputMatrixFromStream(int noOfRows, int noOfColumns, StreamReader streamReader)
//        {
//            // one more column we'll add for row-index
//            int[,] inputMatrix = new int[noOfRows, noOfColumns];
//            String lineString;

//            // prepare the input matrix
//            for (int i = 0; i < noOfRows; i++)
//            {
//                lineString = streamReader.ReadLine().Trim();
//                string[] inputString = lineString.Split(' '); //.Select(x => Convert.ToInt32(x.Trim())).ToArray();


//                int[] intArray = new int[inputString.Length];
//                for (int k = 0; k < inputString.Length; k++)
//                {
//                    intArray[k] = Convert.ToInt32(inputString[k].Trim());
//                }


//                inputMatrix[i, 0] = intArray[0];
//                inputMatrix[i, 1] = intArray[1];
//                inputMatrix[i, 2] = i;  // it determines the rowIndex
//            }

//            return inputMatrix;
//        }


//        private static void ParentingPartneringReturnsConsole()
//        {
//            String line;
//            int noOfTestCases;


//            //Read the first line of text
//            line = Console.ReadLine(); // streamReader.ReadLine().Trim();
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
//                    int noOfRows = Convert.ToInt32(line.Trim());

//                    // There will be always two columns (Start time, End time)
//                    int[,] currentMatrix = GetCurrentInputMatrix(noOfRows, noOfColumns: 2);
//                    var allocatedWork = SolveForMatrix(currentMatrix, noOfRows);

//                    Console.WriteLine("Case #" + testCaseNo + ": " + allocatedWork);

//                }

//                // let's move to test next test case
//                testCaseNo++;
//            }

//            //close the file
//            // streamReader.Close();
//        }

//        private static string SolveForMatrix(int[,] inputMatrix, int noOfRows)
//        {
//            // let's allocate the task between Cameron and Jamie

//            // Let's first alocate to J 
//            // sort matrix based on start time
//            inputMatrix = SortMatrixOnRowsFirstValues(inputMatrix);
//            string[] workAllocation = new string[noOfRows];

//            MyKeyValuePair jamesAlloc = null;
//            MyKeyValuePair cameronAlloc = null;

//            bool isPreConflictJames = false;

//            // Now iterate through each rows
//            for (int i = 0; i < noOfRows; i++)
//            {
//                // first check if End time of (previous allocated task) exceed this Start time of this iteration then set the allocation NULL: Assume task is already finished.
//                if (jamesAlloc != null)
//                {
//                    // 0th Index: Start Time || 1st Index: End Time
//                    if (inputMatrix[i, 0] >= jamesAlloc.End)
//                        jamesAlloc = null;
//                }

//                // first check if End time of (previous allocated task) exceed this Start time of this iteration then set the allocation NULL: Assume task is already finished.
//                if (cameronAlloc != null)
//                {
//                    // 0th Index: Start Time || 1st Index: End Time
//                    if (inputMatrix[i, 0] >= cameronAlloc.End)
//                        cameronAlloc = null;
//                }

//                // If no task allocated to anyone
//                // give preferance to James
//                if (jamesAlloc == null & cameronAlloc == null)
//                {
//                    if (isPreConflictJames)
//                    {
//                        // then create for Cameron
//                        cameronAlloc = new MyKeyValuePair
//                        {
//                            Start = inputMatrix[i, 0],
//                            End = inputMatrix[i, 1]
//                        };

//                        workAllocation[i] = "C";

//                        isPreConflictJames = false;
//                    }
//                    else
//                    {
//                        // James
//                        jamesAlloc = new MyKeyValuePair
//                        {
//                            Start = inputMatrix[i, 0],
//                            End = inputMatrix[i, 1]
//                        };

//                        workAllocation[i] = "J";
//                        isPreConflictJames = true;
//                    }
//                }
//                else if (jamesAlloc == null) //&& cameronAlloc == null)
//                {
//                    jamesAlloc = new MyKeyValuePair
//                    {
//                        Start = inputMatrix[i, 0],
//                        End = inputMatrix[i, 1]
//                    };

//                    workAllocation[i] = "J";
//                }
//                else if (cameronAlloc == null)
//                {
//                    cameronAlloc = new MyKeyValuePair
//                    {
//                        Start = inputMatrix[i, 0],
//                        End = inputMatrix[i, 1]
//                    };

//                    workAllocation[i] = "C";
//                }
//            }

//            // Ok, let's check if re
//            StringBuilder sbReturnValue = new StringBuilder();
//            for (int s = 0; s < workAllocation.Length; s++)
//            {
//                if (string.IsNullOrWhiteSpace(workAllocation[s]))
//                {
//                    return "IMPOSSIBLE";
//                }
//                else
//                {
//                    sbReturnValue.Append(workAllocation[s]);
//                }
//            }

//            return sbReturnValue.ToString();
//        }

//        private static int[,] SortMatrixOnRowsFirstValues(int[,] inputMatrix)
//        {
//            for (int i = 0; i < inputMatrix.GetLength(0); i++)
//            {
//                for (int j = i; j < inputMatrix.GetLength(0); j++) // no of columns
//                {
//                    if (inputMatrix[i, 0] > inputMatrix[j, 0]) // sort by ascending by first index of each row
//                    {
//                        for (int k = 0; k < inputMatrix.GetLength(1); k++)
//                        {
//                            var temp = inputMatrix[i, k];
//                            inputMatrix[i, k] = inputMatrix[j, k];
//                            inputMatrix[j, k] = temp;
//                        }
//                    }
//                }
//            }

//            return inputMatrix;
//        }


//        private static int[,] GetCurrentInputMatrix(int noOfRows, int noOfColumns) //, StreamReader streamReader)
//        {
//            int[,] inputMatrix = new int[noOfRows, noOfColumns];
//            String lineString;

//            // prepare the input matrix
//            for (int i = 0; i < noOfRows; i++)
//            {
//                lineString = Console.ReadLine(); // streamReader.ReadLine().Trim();
//                string[] inputString = lineString.Split(' '); //.Select(x => Convert.ToInt32(x.Trim())).ToArray();


//                int[] intArray = new int[inputString.Length];
//                for (int k = 0; k < inputString.Length; k++)
//                {
//                    intArray[k] = Convert.ToInt32(inputString[k].Trim());
//                }


//                inputMatrix[i, 0] = intArray[0];
//                inputMatrix[i, 1] = intArray[1];
//                inputMatrix[i, 2] = i;  // it determines the rowIndex
//            }

//            return inputMatrix;
//        }

//    }

//    class MyKeyValuePair
//    {
//        public int Start { get; set; }
//        public int End { get; set; }
//    }
//}