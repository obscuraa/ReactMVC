using MathNet.Numerics.Distributions;

namespace ReactMVC
{
    public class PoissonDistribution : IProbabilityDistribution
    {
        public double GetRadius()
        {
            double mean = 100;
            MathNet.Numerics.Distributions.Poisson poissonDist = new Poisson(mean);
            double randomGaussianValue = poissonDist.Probability((int)mean);
            return randomGaussianValue;
        }
    }
}
