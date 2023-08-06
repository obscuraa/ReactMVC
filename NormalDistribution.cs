using MathNet.Numerics.Distributions;

namespace ReactMVC
{
    public class NormalDistribution : IProbabilityDistribution
    {
        public double GetRadius()
        {
            double mean = 10;
            double stdDev = 3.5;

            MathNet.Numerics.Distributions.Normal normalDist = new Normal(mean, stdDev);
            double randomGaussianValue = normalDist.Sample();
            return randomGaussianValue;
        }
    }
}
