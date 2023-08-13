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
        //List<Thread> threads = new List<Thread>();

        public List<Sphere> GenerateRandomPoints(Sphere sphere, int numPoints)
        {
            Random rand = new Random();
            List<Thread> threads = new List<Thread>();

            double[] radiusArr = new double[numPoints];
            for(int i = 0; i < numPoints; i++)
            {
                radiusArr[i] = normalDistribution.GetRadius();
            }

            radiusArr.OrderBy(x => x);

            //генерация нового инстанса
            double sp_x = RandCoordinateX(sphere, rand);
            double sp_y = RandCoordinateY(sphere, rand);
            double sp_z = RandCoordinateZ(sphere, rand);
            double sp_Radius = radiusArr[0];

            var sp = new Sphere(sp_x, sp_y, sp_z, sp_Radius);

            for (int i = 0; i < numPoints; i++)
            {
                double x = RandCoordinateX(sphere, rand);
                double y = RandCoordinateY(sphere, rand);
                double z = RandCoordinateZ(sphere, rand);
                double Radius = radiusArr[i];

                points.Add(new Sphere(x, y, z, Radius));

                if (Logic.Intersect(points[i], sp, numPoints))
                {
                    list.Add(points.ElementAt(i));
                }
            }

            foreach (Thread t in threads)
            {
                t.Join();
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

        public static bool Intersect(Sphere current, Sphere previous, int n)
        {
            int i;
            if (n > 0)
            {
                i = 0;
                while (i < n)
                {
                    if (Math.Sqrt(Math.Pow(current.X, 2) + Math.Pow(current.Y, 2) + Math.Pow(current.Z, 2)) < current.Radius + previous.Radius)
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
