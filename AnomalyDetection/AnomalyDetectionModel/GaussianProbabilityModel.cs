using Accord.Math;
using Accord.Statistics;
using Accord.Statistics.Distributions.Multivariate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnomalyDetection.AnomalyDetectionModel
{
    public class GaussianProbabilityModel : IProbabilityModel
    {
        private int m; // num rows / num examples
        private int n; // num cols / num features

        private double[] mean;
        private double[,] cov;
        private MultivariateNormalDistribution probModel;
        private double threshold;

        public GaussianProbabilityModel(double[,] dataset, double threshold)
        {
            this.m = dataset.GetLength(0);
            this.n = dataset.GetLength(1);

            if ( m <= n)
            {
                throw new Exception("The number of examples must be greater than number of features");
            }

            this.mean = Measures.Mean(dataset, 0);
            this.cov = Measures.Covariance(dataset, this.mean);
            this.threshold = threshold;
           
            if (Matrix.Determinant(cov) == 0)
            {
                throw new Exception("Determinant of covariance matrix is 0. Try to add more example.");
            }

            this.probModel = new MultivariateNormalDistribution(this.mean, this.cov);
        }

        public string getMeanVector()
        {
            return "[ " + string.Join(", ", mean) +" ]";
        }

        public string getCovarianceMatrix()
        {
            string result = Environment.NewLine;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                     result += cov[i, j] + " ";
                }
                result += Environment.NewLine;
            }
            return result;
        }

        public double evaluate(double[] x){
            return probModel.ProbabilityDensityFunction(x);
        }

        public bool isAnomaly(double[] x)
        {
            return evaluate(x) < threshold;
        }
    }
}
