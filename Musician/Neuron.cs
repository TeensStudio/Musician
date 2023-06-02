using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static Musician.Form1;

namespace Musician
{
    public class Neuron
    {
        private static int n_result;
        private int A;
        private int GrayScale;

        public Neuron(Color colors)
        {
            A = colors.A;
            GrayScale = (colors.R + colors.G + colors.B) / 3;

            Summator();
        }

        private static int[] Get_weight()
        {
            Random random = new Random();

            int[] weights = new int[2];

            weights[0] = random.Next(255);
            weights[1] = random.Next(maxValue: 255);

            return weights;
        }

        private void Summator()
        {
            int summ = (A * Get_weight()[0]) + (GrayScale * Get_weight()[1]);

            n_result = summ * 9;
        }
        public static int Get_n_result()
        {
            return n_result;
        }
    }
}