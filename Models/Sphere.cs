namespace ReactMVC.Models
{
    public class Sphere : IShape
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Radius { get; set; }
        //размер ограничивающей области rglobal(double)
        //public double Rglobal { get; set; }
        //число файлов(int) (т.е. сколько раз мы хотим осуществить генерацию)
        //public int NumberOfFiles { get; set; }
        //public int NumOfSpheres { get; set; }

        public Sphere(double x, double y, double z, double radius)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Radius = radius;
        }

        public double Area()
        {
            return 4 * Math.PI * Math.Pow(Radius, 2);
        }

        public double Volume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3);
        }

        public static double Concentration(double v_global, List<Sphere> spheres) =>  spheres.Sum(item => item.Volume() / v_global);
        

        //double[] arr = new double[3];

        //public double[] GenerateArray(double[] arr) 
        //{
        //    Random random = new Random();
        //    for(int i  = 0; i < arr.Length; i++)
        //    {
        //        arr[i]= random.NextDouble();
        //    }
        //    Array.Sort(arr);
        //    return arr; 
        //}

        //List<Sphere> points = new List<Sphere>();
        //List<Sphere> list = new List<Sphere>();

        //public Sphere(double x, double y, double z)
        //{
        //    X = x;
        //    Y = y;
        //    Z = z;
        //}

        //public List<Sphere> GenerateRandomPoints(double a, double b, double c, int numPoints)
        //{
        //    //List<Sphere> points = new List<Sphere>();
        //    Random rand = new Random();

        //    for (int i = 0; i < numPoints; i++)
        //    {
        //        double x = rand.NextDouble() * 2 * a - a;
        //        double y = rand.NextDouble() * 2 * b - b;
        //        double z = rand.NextDouble() * 2 * c - c;

        //        points.Add(new Sphere(x, y, z));
        //        if (Sphere.InSphere(points.ElementAt(i)) == true)
        //        {
        //            if (Sphere.Intersect(points.ElementAt(i), points.ElementAt(i-1)) == true)
        //            {
        //                list.Add(list.ElementAt(i));
        //            }
        //        }
        //    }

        //    return points;
        //}

        //public static bool InSphere(Sphere sphere)
        //{
        //    if (Math.Sqrt(Math.Pow(sphere.X, 2) + Math.Pow(sphere.Y, 2) + Math.Pow(sphere.Z, 2)) > sphere.Radius)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //public static bool Intersect(double x, double y, double z, double[] r, double x0, double y0, double z0, double r0, double r_global, int n)
        //{
        //    int i;
        //    if (n > 0)
        //    {
        //        i = 0;
        //        while (i < n)
        //        {
        //            if (Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2)) < r[i] + r0)
        //            {
        //                return false;
        //            }
        //            i += 1;
        //        }
        //    }
        //    return true;
        //}
    }
}
