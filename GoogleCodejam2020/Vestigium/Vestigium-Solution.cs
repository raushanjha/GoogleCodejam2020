//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace GoogleCodejam2020
//{
//    public class Solution
//    {
//        static void Main(string[] args)
//        {
//            // read input test file
//            //if (args.Length > 0)
//            {
//                VestigiumSolutionStarterFromFile(args[0]);
//            }
//        }

//        private static void VestigiumSolutionStarterFromFile(string fileRelativePath)
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
//                    int currentMatrixSize = Convert.ToInt32(line.Trim());
//                    int[,] currentMatrix = GetCurrentInputMatrixStreamReader(currentMatrixSize, streamReader);

//                    if (!IsNotNaturalSquareMatrix(currentMatrixSize, currentMatrix))
//                    {
//                        CurrentMatrixSolution(testCaseNo, currentMatrixSize, currentMatrix);
//                    }
//                    else
//                    {
//                        Console.WriteLine("Case #" + testCaseNo + ": " + 0 + " " + 0 + " " + 0);
//                    }
//                }

//                // let's move to test next test case
//                testCaseNo++;
//            }

//            //close the file
//            streamReader.Close();
//        }

//        private static void VestigiumSolutionStarter() //(string fileRelativePath)
//        {
//            String line;
//            int noOfTestCases;

//            ////Pass the file path and file name to the StreamReader constructor
//            //StreamReader streamReader = new StreamReader(fileRelativePath);

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
//                    int currentMatrixSize = Convert.ToInt32(line.Trim());
//                    int[,] currentMatrix = GetCurrentInputMatrix(currentMatrixSize);

//                    if (!IsNotNaturalSquareMatrix(currentMatrixSize, currentMatrix))
//                    {
//                        CurrentMatrixSolution(testCaseNo, currentMatrixSize, currentMatrix);
//                    }
//                    else
//                    {
//                        Console.WriteLine("Case #" + testCaseNo + ": " + 0 + " " + 0 + " " + 0);
//                    }
//                }

//                // let's move to test next test case
//                testCaseNo++;
//            }

//            //close the file
//            // streamReader.Close();
//        }

//        private static void CurrentMatrixSolution(int testCaseNo, int matrixSize, int[,] inputMatrix)
//        {
//            int trace = 0;
//            int r = 0;
//            int c = 0;



//            for (int i = 0; i < matrixSize; i++)
//            {
//                Dictionary<int, int> rowHash = new Dictionary<int, int>();
//                Dictionary<int, int> colHash = new Dictionary<int, int>();
//                bool doesRowHasDuplicate = false;
//                bool doesColHasDuplicate = false;

//                for (int j = 0; j < matrixSize; j++)
//                {
//                    if (i == j)
//                        trace += inputMatrix[i, j];

//                    //  row calculation inputMatrix[i, j] 
//                    if (rowHash.ContainsKey(inputMatrix[i, j])) // && doesRowHasDuplicate == false)
//                    {
//                        if (!doesRowHasDuplicate)
//                        {
//                            doesRowHasDuplicate = true;
//                            r++;
//                        }
//                    }
//                    else
//                    {
//                        rowHash.Add(inputMatrix[i, j], 1);
//                    }

//                    //
//                    if (colHash.ContainsKey(inputMatrix[j, i])) // && doesColHasDuplicate == false)
//                    {
//                        if (!doesColHasDuplicate)
//                        {
//                            doesColHasDuplicate = true;
//                            c++;
//                        }
//                    }
//                    else
//                    {
//                        colHash.Add(inputMatrix[j, i], 1);
//                    }
//                }
//            }

//            // output
//            Console.WriteLine("Case #" + testCaseNo + ": " + trace + " " + r + " " + c);
//        }

//        private static bool IsNotNaturalSquareMatrix(int matrixSize, int[,] inputMatrix)
//        {
//            // first check if it's a natural latin square or not
//            for (int i = 0; i < matrixSize; i++)
//            {
//                for (int j = 0; j < matrixSize; j++)
//                {
//                    if (1 <= inputMatrix[i, j] && inputMatrix[i, j] <= matrixSize)
//                    {
//                        continue;
//                    }
//                    else
//                    {
//                        return true;
//                    }
//                }
//            }

//            return false;
//        }

//        private static int[,] GetCurrentInputMatrixStreamReader(int matrixSize, StreamReader streamReader)
//        {
//            int[,] inputMatrix = new int[matrixSize, matrixSize];
//            String lineString;

//            // prepare the input matrix
//            for (int i = 0; i < matrixSize; i++)
//            {
//                lineString = streamReader.ReadLine().Trim();
//                string[] inputString = lineString.Split(' '); //.Select(x => Convert.ToInt32(x.Trim())).ToArray();


//                int[] intArray = new int[inputString.Length];
//                for (int k = 0; k < inputString.Length; k++)
//                {
//                    intArray[k] = Convert.ToInt32(inputString[k].Trim());
//                }

//                // populate the (i)th row of matrix
//                for (int j = 0; j < matrixSize; j++)
//                {
//                    inputMatrix[i, j] = intArray[j];
//                }
//            }

//            return inputMatrix;
//        }

//        private static int[,] GetCurrentInputMatrix(int matrixSize) //, StreamReader streamReader)
//        {
//            int[,] inputMatrix = new int[matrixSize, matrixSize];
//            String lineString;

//            // prepare the input matrix
//            for (int i = 0; i < matrixSize; i++)
//            {
//                lineString = Console.ReadLine(); // streamReader.ReadLine().Trim();
//                string[] inputString = lineString.Split(' '); //.Select(x => Convert.ToInt32(x.Trim())).ToArray();


//                int[] intArray = new int[inputString.Length];
//                for (int k = 0; k < inputString.Length; k++)
//                {
//                    intArray[k] = Convert.ToInt32(inputString[k].Trim());
//                }

//                // populate the (i)th row of matrix
//                for (int j = 0; j < matrixSize; j++)
//                {
//                    inputMatrix[i, j] = intArray[j];
//                }
//            }

//            return inputMatrix;
//        }

//    }
//}