using AnomalyDetection.AnomalyDetectionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnomalyDetection.AnomalyDetectionModel
{
    public enum MODELTYPE
    {
        GAUSSIAN
    };

    public class AnomalyModelFactory
    {
        public static IProbabilityModel createModel(double[,] dataset, MODELTYPE modelType, double threshold)
        {
            switch (modelType)
            {
                case(MODELTYPE.GAUSSIAN):
                    return new GaussianProbabilityModel(dataset, threshold);
                default:
                    throw new NotSupportedException("Model type "+modelType+" not supported");
            }
        }
    }
}
