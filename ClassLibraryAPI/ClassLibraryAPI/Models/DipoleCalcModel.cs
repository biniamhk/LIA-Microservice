using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassLibraryAPI.Models
{
    public class DipoleCalcModel : ICalcModel
    {
        public double Add(double paramOne, double paramTwo)
        {
            return paramOne + paramTwo;
        }

        public double GetFrequency(double waveLength)
        {

            return Math.Round(299792458 / (waveLength * Math.Pow(10, 6)), 2);
        }

        public double GetWavelength(double frequency)
        {

            return Math.Round(299792458 / (frequency * Math.Pow(10, 6)), 2);
        }


        public double GetDipoleArmLength(double waveLength)
        {

            return Math.Round(0.95 * (waveLength / 2), 2);
        }

        public double GetDipoleFullLength(double waveLength)
        {
            return Math.Round(0.95 * waveLength, 2);
        }


        public double GetAdjustmentFactor(double waveLength, double diameterOfConductor)
        {
            double hwl = waveLength / 2;
            double R = hwl / diameterOfConductor;
            return Math.Round(0.9787 - Math.Round(11.86497 / Math.Pow(Math.Pow(1 + (R / 0.000449), 1.7925), 0.3), 1), 2);
        }

        public double GetAdjustedDipoleFullLength(double adjustmentFactor, double frequency)
        {
            return 0.5 * adjustmentFactor * 299792458 / (frequency * Math.Pow(10, 6));
        }

    }
}
