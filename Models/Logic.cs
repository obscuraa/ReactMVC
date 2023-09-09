using System.IO.Compression;

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
            List<Sphere> list = new List<Sphere>();

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

            return points;
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

        public void PrintEllipsoidFields(List<Sphere> spheres)
        {
            if (spheres.Count == 1)
            {
                PrintFieldsToFile(spheres[0], "spheres.txt");
            }
            else
            {
                Parallel.For(0, spheres.Count, i =>
                //for (int i = 0; i < spheres.Count; i++)
                {
                    string fileName = $"sphere{i + 1}.txt";
                    PrintFieldsToFile(spheres[i], fileName);
                });
                ArchiveFiles();
            }
        }
        // NumOfFiles должен быть меньше чем кол-во элементов в списке, иначе System.ArgumentOutOfRangeException
        public void ThreadablePrintEllipsoidFields(List<Sphere> spheres, int NumberOfFiles)
        {
            if (NumberOfFiles == 1)
            {
                PrintFieldsToFile(spheres[0], "sphere.txt");
            }
            else
            {
                List<Thread> threads = new List<Thread>();
                try
                {
                    for (int i = 0; i < NumberOfFiles; i++)
                    {
                        string fileName = $"{Guid.NewGuid()}.txt";
                        Thread thread = new Thread(() => PrintFieldsToFile(spheres[i], fileName));
                        threads.Add(thread);
                        thread.Start();
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    throw;
                }

                foreach (Thread thread in threads)
                {
                    thread.Join();
                }

                ArchiveFiles();
            }
        }
        private static void PrintFieldsToFile(Sphere sphere, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine($"X: {sphere.X}");
                writer.WriteLine($"Y: {sphere.Y}");
                writer.WriteLine($"Z: {sphere.Z}");
                writer.WriteLine($"Radius: {sphere.Radius}");
            }
        }
        private static void ArchiveFiles()
        {
            string zipFileName = "sphere_archive.zip";
            string[] fileNames = Directory.GetFiles(Directory.GetCurrentDirectory(), "sphere*.txt");

            using (ZipArchive archive = ZipFile.Open(zipFileName, ZipArchiveMode.Create))
            {
                foreach (string fileName in fileNames)
                {
                    archive.CreateEntryFromFile(fileName, Path.GetFileName(fileName));
                }
            }
        }
    }
}
