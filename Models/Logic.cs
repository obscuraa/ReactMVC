namespace ReactMVC.Models
{
    public class Logic
    {
        NormalDistribution normalDistribution = new NormalDistribution();
        public Logic(NormalDistribution normalDistribution)
        {
            normalDistribution.GetRadius();
        }

        List<Sphere> points = new List<Sphere>();
        List<Sphere> list = new List<Sphere>();

        public List<Sphere> GenerateRandomPoints(Sphere sphere, int numPoints)
        {
            Random rand = new Random();

            double[] radiusArr = new double[numPoints];
            for(int i = 0; i < numPoints; i++)
            {
                radiusArr[i] = normalDistribution.GetRadius();
            }

            radiusArr.OrderBy(x => x);

            for (int i = 0; i < numPoints; i++)
            {
                double x = RandCoordinateX(sphere, rand);
                double y = RandCoordinateY(sphere, rand);
                double z = RandCoordinateZ(sphere, rand);
                double Radius = radiusArr[i]; 

                points.Add(new Sphere(x, y, z, Radius));

                if (Logic.InSphere(points.ElementAt(i)) == true)
                {
                    if (Logic.Intersect(points, numPoints))
                    {
                        list.Add(points.ElementAt(i));
                    }
                }
            }
            return list;
        }

        private static double RandCoordinateZ(Sphere sphere, Random rand)
        {
            return rand.NextDouble() * 2 * sphere.Z - sphere.Z;
        }

        private static double RandCoordinateY(Sphere sphere, Random rand)
        {
            return rand.NextDouble() * 2 * sphere.Y - sphere.Y;
        }

        private static double RandCoordinateX(Sphere sphere, Random rand)
        {
            return rand.NextDouble() * 2 * sphere.X - sphere.X;
        }

        public static bool InSphere(Sphere sphere)
        {
            if (Math.Sqrt(Math.Pow(sphere.X, 2) + Math.Pow(sphere.Y, 2) + Math.Pow(sphere.Z, 2)) > sphere.Radius)
            {
                return false;
            }
            return true;
        }

        public static bool Intersect(List<Sphere> list, int n)
        {
            int i;
            if (n > 0)
            {
                i = 0;
                while (i < n)
                {
                    if (Math.Sqrt(Math.Pow(list[i].X, 2) + Math.Pow(list[i].Y, 2) + Math.Pow(list[i].Z, 2)) < list[i].Radius + list[0].Radius)
                    {
                        return false;
                    }
                    i += 1;
                }
            }
            return true;
        }
    }
}
