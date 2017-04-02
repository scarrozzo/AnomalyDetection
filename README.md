# AnomalyDetection
Machine Learning - Anomaly detection library

This library implement the unsupervised machine learning algorithm for anomaly detection (for theory see: https://www.coursera.org/learn/machine-learning/home/week/9).
It is based on Accord .NET framework library.

-The visual studio solution includes:
1) AnomalyDetection library project: contains the classes to build the multivariate gaussian probability model.
2) CATestAnomalyDetection console application project: show some usage examples.


-Quick start:

    // create a probability model (only multivariate gaussian is supported for now)
    IProbabilityModel probModel = AnomalyModelFactory.createModel(<double[,] dataset>, MODELTYPE.GAUSSIAN, <threshold>);
    
    // print parameters used by the probability model
    Console.WriteLine("Mean: {0}", probModel.getMeanVector());
    Console.WriteLine("Covariance: {0}", probModel.getCovarianceMatrix());
    
    // evaluate the probability for a new test example
    Console.WriteLine("Calculated probability: {0}", probModel.evaluate(x));
    
    // say if a test example is an anomaly
    Console.WriteLine("Is anomaly: {0}", probModel.isAnomaly(x));
    



