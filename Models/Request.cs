using System.IO.Compression;

namespace ReactMVC.Models
{
    public class Request
    {
        //public double RI { get; set; }
        //spheres number(int) - число шаров планируемое
        public int Number { get; set; }
        //nc(double) - концентрация шаров которую мы хотим получить определяется как sum(r_i^3)  / r^3,
        //public double NC { get; set; }
        //размер самого большого(r_i) (double)
        //public double MaxRI { get; set; }
        //размер самого малого(r_i) (double)
        //public double MinRI { get; set; }
        //вид распределения радиусов r_i(комбобокс):-гаусово-нормальное-любое на твоё усмотрение
        //public double DistributionRI { get; set; }
        //размер ограничивающей области rglobal(double)
        public double Rglobal { get; set; }
        //тип ограничивающей области(комбобокс:сфера, куб )
        //public string? BoundingArea { get; set; }
        //тип распределения для генерации x,y,z центров(комбобокс:гамма, гаусово, рядом будут расположены дополнительные поля для ввода shape(double), scale(double) по которым будет происходить генерация)
        //public string? GenerateCentreCoords { get; set; }
        //public double Shape { get; set; }
        //public double Scale { get; set; }
        //число файлов(int) (т.е. сколько раз мы хотим осуществить генерацию)
        public int FilesNumber { get; set; }
        //try_count число попыток запихнуть шар в систему(если не лезет) - (int)
        //public int TryCount { get; set; }
        //excess доп параметр , по умолчанию excess = 1.005 (double)
        //public double Excess = 1.005;

        //C-шный код 
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

        //public static bool InSphere(Sphere sphere)
        //{
        //    if (Math.Sqrt(Math.Pow(sphere.X, 2) + Math.Pow(sphere.Y, 2) + Math.Pow(sphere.Z, 2)) > sphere.Radius)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        //public static double Uniform(double a, double b)
        //{
        //    var rand = new Random();
        //    return rand.NextDouble() / (rand.NextDouble() + 1.0) * (b - a) + a;
        //}

        //public static double Concentration(double r_global, double[] vr)
        //{
        //    double result = 0;
        //    //foreach (double value in vr)
        //    //{
        //    //    result += Math.Pow(value, 3);
        //    //}
        //    for (int i = 0; i < vr.Length; i++)
        //    {
        //        result  += Math.Pow(vr[i], 3);
        //    }
        //    return result / Math.Pow(r_global, 3);
        //}
        // конец C-шного кода
        
        public void PrintEllipsoidFields(List<Request> ellipsoids)
        {
            if (ellipsoids.Count == 1)
            {
                PrintFieldsToFile(ellipsoids[0], "ellipsoid.txt");
            }
            else
            {
                Parallel.For(0, ellipsoids.Count, i =>
                //for (int i = 0; i < ellipsoids.Count; i++)
                {
                    string fileName = $"ellipsoid{i + 1}.txt";
                    PrintFieldsToFile(ellipsoids[i], fileName);
                });
                ArchiveFiles();
            }
        }

        public void ThreadablePrintEllipsoidFields(List<Request> ellipsoids, int NumberOfFiles)
        {
            if (NumberOfFiles == 1)
            {
                PrintFieldsToFile(ellipsoids[0], "ellipsoid.txt");
            }
            else
            {
                List<Thread> threads = new List<Thread>();

                for (int i = 0; i < NumberOfFiles; i++)
                {
                    string fileName = $"{Guid.NewGuid()}.txt";
                    Thread thread = new Thread(() => PrintFieldsToFile(ellipsoids[i], fileName));
                    threads.Add(thread);
                    thread.Start();
                }

                foreach (Thread thread in threads)
                {
                    thread.Join();
                }

                ArchiveFiles();
            }
        }
        private static void PrintFieldsToFile(Request ellipsoid, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine($"Number: {ellipsoid.Number}");
                writer.WriteLine($"Rglobal: {ellipsoid.Rglobal}");
                writer.WriteLine($"FilesNumber: {ellipsoid.FilesNumber}");
            }
        }
        private static void ArchiveFiles()
        {
            string zipFileName = "ellipsoid_archive.zip";
            string[] fileNames = Directory.GetFiles(Directory.GetCurrentDirectory(), "ellipsoid*.txt");

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