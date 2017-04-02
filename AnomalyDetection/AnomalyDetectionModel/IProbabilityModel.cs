using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnomalyDetection.AnomalyDetectionModel
{
    public interface IProbabilityModel
    {
        string getMeanVector();
        string getCovarianceMatrix();
        bool isAnomaly(double[] x);
        double evaluate(double[] x);
    }
}
