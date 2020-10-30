
using System;

using System.IO;

namespace _34thCCC
{
    class Program
    {
        static void Main(string[] args)
        {
            string level = "4";

            for (int idx = 6; idx <= 6; idx++)
            {
                StreamReader fileInput = new StreamReader($@"../../IO/Input/level{level}/level{level}_{idx}.in");
                StreamWriter fileOutput = new StreamWriter($@"../../IO/Output/level{level}/level{level}_{idx}.out");

                int power = int.Parse(fileInput.ReadLine());
                long maxElectricityBill = long.Parse(fileInput.ReadLine());

                int n = int.Parse(fileInput.ReadLine());
                int[] a = new int[n + 1];

                for (int i = 1; i <= n; i++)
                    a[i] = int.Parse(fileInput.ReadLine());

                int m = int.Parse(fileInput.ReadLine());
                Console.WriteLine(m);
                fileOutput.WriteLine(m);

                for (int i = 1; i <= m; i++)
                {
                    int[] line = Array.ConvertAll(fileInput.ReadLine().Split(), int.Parse);
                    int st = line[2] + 1, dr = line[3] + 1;
                    int currentPower = line[1];

                    Console.Write($"{line[0]}");
                    fileOutput.Write($"{line[0]}");

                    int[] c = new int[n + 1];
                    a.CopyTo(c, 0);

                    while (currentPower > 0)
                    {

                        int mini = Int32.MaxValue;
                        int imini = -1;




                        for (int k = st + 1; k <= dr; k++)
                            if (c[k] < mini && c[k] != -1)
                            {
                                mini = c[k];
                                imini = k - 1;
                            }

                        c[imini + 1] = -1;



                        Console.Write($" {imini} {(currentPower > power ? power : currentPower)}");
                        fileOutput.Write($" {imini} {(currentPower > power ? power : currentPower)}");

                        currentPower -= power;
                    }
                    Console.WriteLine();
                    fileOutput.WriteLine();
                }

                Console.WriteLine($"level{level}_{idx}.in done");
                fileInput.Close();
                fileOutput.Close();
            }
        }
    }
}
