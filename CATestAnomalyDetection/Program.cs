using Accord.Math;
using AnomalyDetection.AnomalyDetectionModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATestAnomalyDetection
{
    class Program
    {
        static void Main(string[] args)
        {
            // read dataset from file
            double[,] dataset = readMatrixFromFile(@"./dataset.txt");

            // create a probability model (only multivariate gaussian is supported for now)
            IProbabilityModel probModel = AnomalyModelFactory.createModel(dataset, MODELTYPE.GAUSSIAN, 0.001);
            
            // print parameters used by the probability model
            Console.WriteLine("Mean: {0}", probModel.getMeanVector());
            Console.WriteLine("Covariance: {0}", probModel.getCovarianceMatrix());

            // some test example -> say if the test example is an anomaly or not
            for(int i = 0; i < 10; i++){
                Random rnd = new Random();
                double[] x = new double[] { rnd.Next(1, 20), rnd.Next(1, 20) };
                Console.WriteLine("Test example: x=({0}, {1})", x[0], x[1]);
                Console.WriteLine("Calculated probability: {0}", probModel.evaluate(x));
                Console.WriteLine("Is anomaly: {0}", probModel.isAnomaly(x));
            }
        }

        private static double[,] readMatrixFromFile(string path)
        {

            double[][] dataset = File.ReadAllLines(path).Select(l => l.Split(' '))
                .Select(l => l.Select(s => Convert.ToDouble(s)).ToArray()).ToArray();

            return JaggedToMultidimensional(dataset);
        }

        private static T[,] JaggedToMultidimensional<T>(T[][] jaggedArray)
        {
            int rows = jaggedArray.Length;
            int cols = jaggedArray.Max(subArray => subArray.Length);
            T[,] array = new T[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                cols = jaggedArray[i].Length;
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = jaggedArray[i][j];
                }
            }
            return array;
        }
    }
}
