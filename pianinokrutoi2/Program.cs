using System;
using System.Collections.Generic;
using System.Threading;

class Piano
{
    static double[] whiteKeysFrequencies = { 100.00, 105.00, 110.00, 121.00, 125.00, 134.00, 150.00, 210.50, 230.70, 280.50, 300.50, 340.00, 360.00, 350.00, 400.08, 410.50, 415.00, 420.00, 430.00, 450.00, 460.00, 470.00, 500.00, 510.00, 515.00, 520.00 };
    static int currentOctave = 4;

    static void PlaySound(double frequency, int duration)
    {
        Console.Beep((int)frequency, duration);
    }

    static double[] GetOctaveFrequencies(int octave)
    {
        double baseFrequency = 261.63;
        double[] octaveFrequencies = new double[whiteKeysFrequencies.Length];
        for (int i = 0; i < whiteKeysFrequencies.Length; i++)
        {
            octaveFrequencies[i] = baseFrequency * Math.Pow(2, i / 7.0);
        }

        return octaveFrequencies;
    }

    static void Main(string[] args)
    {
        double[] currentOctaveFrequencies = GetOctaveFrequencies(currentOctave);

        Console.WriteLine("Добро пожаловать в виртуальное пианино!");
        Console.WriteLine("Используйте клавиши для воспроизведения нот.");
        Console.WriteLine("Используйте клавиши F1, F2, F3, F4 для изменения октавы (1-4).");

        Dictionary<ConsoleKey, int> keyToIndex = new Dictionary<ConsoleKey, int>
        {
            { ConsoleKey.Q, 0 },
            { ConsoleKey.W, 1 },
            { ConsoleKey.E, 2 },
            { ConsoleKey.R, 3 },
            { ConsoleKey.T, 4 },
            { ConsoleKey.Y, 5 },
            { ConsoleKey.U, 6 },
            { ConsoleKey.I, 7 },
            { ConsoleKey.O, 8 },
            { ConsoleKey.P, 9 },
            { ConsoleKey.A, 10 },
            { ConsoleKey.S, 11 },
            { ConsoleKey.D, 12 },
            { ConsoleKey.F, 13 },
            { ConsoleKey.G, 14 },
            { ConsoleKey.H, 15 },
            { ConsoleKey.J, 16 },
            { ConsoleKey.K, 17 },
            { ConsoleKey.L, 18 },
            { ConsoleKey.Z, 19 },
            { ConsoleKey.X, 20 },
            { ConsoleKey.C, 21 },
            { ConsoleKey.V, 22 },
            { ConsoleKey.B, 23 },
            { ConsoleKey.N, 24 },
            { ConsoleKey.M, 25 },
        };

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Escape)
                    break;

                if (keyInfo.Key >= ConsoleKey.F1 && keyInfo.Key <= ConsoleKey.F4)
                {
                    currentOctave = (int)keyInfo.Key - (int)ConsoleKey.F1 + 1;
                    currentOctaveFrequencies = GetOctaveFrequencies(currentOctave);
                    Console.WriteLine("Текущая октава: " + currentOctave);
                }
                else if (keyToIndex.ContainsKey(keyInfo.Key))
                {
                    int keyIndex = keyToIndex[keyInfo.Key];
                    if (keyIndex < currentOctaveFrequencies.Length)
                    {
                        PlaySound(currentOctaveFrequencies[keyIndex], 300);
                    }
                }
            }

            Thread.Sleep(10);
        }
    }
}
