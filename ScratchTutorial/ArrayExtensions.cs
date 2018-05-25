using System;

namespace ScratchTutorial
{
    static class ArrayExtensions
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this T[] array)
        {
            var i = array.Length;
            while (i > 1)
            {
                i--;
                var j = rng.Next(i + 1);
                var temp = array[j];
                array[j] = array[i];
                array[i] = temp;
            }
        }
    }
}
