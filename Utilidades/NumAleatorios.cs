using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class NumAleatorios
    {
        private static Random random = new Random();

        public static int Roll20SidedDice()
        {
            return random.Next(1, 21); // Generates a random number between 1 and 20
        }

        public static int Roll6SidedDice()
        {
            return random.Next(1, 7); // Generates a random number between 1 and 6
        }

        private static int seed = Environment.TickCount;

        public static int RandomNumberRange(int minValue, int maxValue)
        {
            seed = (seed * 1103515245 + 12345) & 0x7FFFFFFF;
            double normalized = (double)seed / 0x7FFFFFFF;
            int range = maxValue - minValue + 1;
            return (int)(minValue + normalized * range);
        }

        public static float RandomFloat()
        {
            seed = (seed * 1103515245 + 12345) & 0x7FFFFFFF;
            return (float)seed / 0x7FFFFFFF;
        }

        public static int RandomNumberCustomSeed(int seed)
        {
            int semilla = (seed * 1103515245 + 12345) & 0x7FFFFFFF;
            double normalized = (double)seed / 0x7FFFFFFF;
            return (int)normalized;
        }
    }
}
