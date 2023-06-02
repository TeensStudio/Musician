using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;

namespace Musician
{
    public class Music_Convertation
    {
        public Music_Convertation(int[] frequency)
        {
            for (int i = 0; i < frequency.Length; i++)
            {
                if (frequency[i] > 32767)
                    frequency[i] /= 1000;
                
                if(frequency[i] < 37)
                    frequency[i] *= 100;

                Console.Beep(Convert.ToInt32(frequency[i]), Convert.ToInt32(1600 / Math.Pow(frequency[i], .35)));
                Thread.Sleep(Convert.ToInt32(1600 / Math.Pow(frequency[i], .35)));
            }
        }
    }
}