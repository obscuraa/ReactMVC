using MathNet.Numerics.Distributions;
using static ReactMVC.Distribution;

namespace ReactMVC
{
    public class Distribution
    {
        public interface IProbabilityDistribution
        {
            double GetRadius();
        }

        public class NormalDistribution : IProbabilityDistribution
        {
            public double GetRadius()
            {
                double mean = 100;
                double stdDev = 10;

                MathNet.Numerics.Distributions.Normal normalDist = new Normal(mean, stdDev);
                double randomGaussianValue = normalDist.Sample();
                return randomGaussianValue;
            }
        }

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

    //наверное в другой класс надо перенести
    public class Context
    {
        private IProbabilityDistribution probabilityDistribution;

        public Context(IProbabilityDistribution probabilityDistribution)
        {
            this.probabilityDistribution = probabilityDistribution;
        }

        public double CalculateRadius()
        {
            return probabilityDistribution.GetRadius();
        }

        //вызов
        Context NormalDistribution = new Context(new NormalDistribution());
        //double radiusWithNormalDistribution = NormalDistribution.CalculateRadius();

        Context PoissonDistribution = new Context(new PoissonDistribution());
        //double radiusWithPoissonDistribution = PoissonDistribution.CalculateRadius();
    }
}
