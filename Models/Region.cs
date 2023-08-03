using System.Collections.Generic;

namespace ReactMVC.Models
{
    public class Region
    {
        List<Sphere> points = new List<Sphere>();
        List<Sphere> list = new List<Sphere>();

        public List<Sphere> GenerateRandomPoints(double a, double b, double c, int numPoints)
        {
            //List<Sphere> points = new List<Sphere>();
            Random rand = new Random();

            for (int i = 0; i < numPoints; i++)
            {
                double x = rand.NextDouble() * 2 * a - a;
                double y = rand.NextDouble() * 2 * b - b;
                double z = rand.NextDouble() * 2 * c - c;

                points.Add(new Sphere(x, y, z));
                if (Sphere.InSphere(points.ElementAt(i)) == true)
                {
                    if (Sphere.Intersect(points.ElementAt(i), points.ElementAt(i - 1)) == true)
                    {
                        list.Add(list.ElementAt(i));
                    }
                }
            }
            return points;
        }
    }
}
