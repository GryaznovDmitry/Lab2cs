using System;
using System.Collections.Generic;
using System.Numerics;

namespace GryaznovLab2
{
    public class Lab2Main
    {
        static void Main()
        {
  /*          Grid2D item = new Grid2D(10, 10, 3, 3);

            Console.WriteLine("\n\nLab 1\n");
            Console.WriteLine("\nPoint 1_1\n\n");

            V5DataOnGrid DoG = new V5DataOnGrid("Directed by Gryaznov D.", DateTime.Now, item);
            DoG.InitRandom(0, 10);
            Console.WriteLine(DoG.ToLongString("g3"));
            V5DataCollection DC = (V5DataCollection)DoG;
            Console.WriteLine(DC.ToLongString("g3"));

            Console.WriteLine("\n\nPoint 1_2\n\n");

            V5MainCollection MC = new V5MainCollection();
            MC.AddDefaults();
            Console.WriteLine(MC.ToLongString("g3"));

            Console.WriteLine("\n\nPoint 1_3\n\n");

            Vector2[] array;
            foreach (V5Data obj in MC)
            {
                array = obj.NearEqual(2);
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine("[" + array[i].X.ToString("g3") + ", " + 
                                            array[i].Y.ToString("g3") + "]");
                }
            }
*/
            Console.WriteLine("\n\nLab 2\n");

            Console.WriteLine("\nPoint 2_1\n\n");
            Console.Write("Input full file path or press 'Enter': ");
            string path = Console.ReadLine();
            if (path == string.Empty)
            {
                path = "..\\..\\..\\..\\..\\ConsoleApp1\\ConsoleApp1\\V5DefaultText.txt";
            }
            try
            {
                V5DataOnGrid DoG2 = new V5DataOnGrid(path);
                Console.WriteLine(DoG2.ToLongString("g3"));
            }
            catch (Exception)
            {
                Console.WriteLine($"Using file {path}\nV5DataOnGrid object wasn't created correctly\n");
            }

            Console.WriteLine("\n\nPoint 2_2\n\n");
            V5MainCollection MC2 = new V5MainCollection();
            MC2.AddDefaults();
            Console.WriteLine(MC2.ToLongString("g3"));
            Console.WriteLine("MinVecLen for DataCollection: " + MC2.MinVecLenDC.ToString("g3") + "\n");
            IEnumerable<DataItem> CML = MC2.CollMinElems;
            Console.WriteLine("\nMin Values for MainCollection:\n");
            foreach (DataItem item in CML)
            {
                Console.WriteLine(item.ToString("g3") + "\n");
            }
            IEnumerable<Vector2> points = MC2.Points;
            Console.WriteLine("\npoints in DoG and out DC:\n");
            foreach (Vector2 item in points)
            {
                Console.WriteLine(item.ToString("g3") + "\n");
            }
        }
    }
}
