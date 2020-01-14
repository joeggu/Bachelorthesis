using System;
using OpenCvSharp;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Projective Transformations");
            TransformTv();
            Console.WriteLine("Transformation finished");
        }

        public static void TransformTv()
        {
            Mat img = Cv2.ImRead(@"C:\prog\consoleHomography\ConsoleApp1\ConsoleApp1\images\input\in.jpg");
            Mat imgOut = new Mat();

            Point2f[] source =
            {
                new Point2f(62f,59f),
                new Point2f(420f,112f),
                new Point2f(425f,300f),
                new Point2f(50f,265f)
            };
            MatOfPoint2f src = MatOfPoint2f.FromArray(source);

            Point2f[] destination =
            {
                new Point2f(0f,0f),
                new Point2f(img.Width,0f),
                new Point2f(img.Width,img.Height),
                new Point2f(0f,img.Height)
            };
            MatOfPoint2f dest = MatOfPoint2f.FromArray(destination);

            Mat m = Cv2.FindHomography(src, dest);
            Cv2.WarpPerspective(img, imgOut, m, img.Size());
            
            string imgName = $"{DateTime.Now:dd_MM_yyyy_HH_mm_ss}_out.jpg";
            Cv2.ImWrite(@"C:\prog\consoleHomography\ConsoleApp1\ConsoleApp1\images\output\" + imgName, imgOut);
        }
    }
}
