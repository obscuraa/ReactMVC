using ReactMVC.Models;

namespace ReactMVC
{
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
