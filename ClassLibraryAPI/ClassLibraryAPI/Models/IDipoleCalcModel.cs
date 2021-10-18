using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassLibraryAPI.Models
{
    public interface ICalcModel
    {
        #region xml
        /// <summary>
        /// Returns a basic addition of parameter One and Two.
        /// </summary>
        #endregion xml
        double Add(double paramOne, double paramTwo);
        #region xml
        /// <summary>
        ///<para> Returns : λ </para>
        /// Wavelength(m/s) given a known frequency(MHz) Two digit decimal.
        /// <para>  (λ = c / f) </para>
        /// </summary>
         #endregion
        double GetWavelength(double frequency);
        #region xml
        /// <summary>
        /// <para>Returns : f </para>
        /// Frequency(MHz) given a known wavelength(m/s) Two digit decimal.
        /// <para>   (f = c / λ) </para>
        /// </summary>
        #endregion
        double GetFrequency(double waveLength);
        #region xml
        ///<summary>
        ///<para>Returns : l</para>  
        ///Dipole arm length(m) given a known wavelength(m/s) Two digit decimal.
        ///<para>  L = 95 / f</para>
        ///<para> (l = L / 2)</para>
        /// </summary>
        #endregion
        double GetDipoleArmLength(double waveLength);

        #region xml
        ///<summary>
        ///<para>Returns L (simplified):</para> Total diapole antenna length (m) given a known wavelength(m/s)
        ///<para>(L = 95 / f)</para>
        ///</summary>
        #endregion
        double GetDipoleFullLength(double waveLength);
        #region xml
        ///<summary>
        ///<para>Returns : k </para> The Adjustment factor.
        ///<para>Given the diameter of the conductor and wavelength </para>
        ///<para> R = 0.5 λ / diameter of a conductor </para>
        /// k= 0.9787 - [(11.86497 / (1 + (R/0.000449)^1.7925)^0.3)]
        ///</summary>
        #endregion
        double GetAdjustmentFactor(double waveLength, double diameterOfConductor);
        #region xml
        ///<summary>
        ///<para> Returns : L </para>The length of the total dipole antenna in meters (m) giving consideration to the adjustment factor.
        ///<para>Given a known adjustment factor and frequency</para>
        ///<para> k = adjustmentFactor </para>
        ///<para>(L = 0.5 * k * c / f) </para>
        ///</summary>
        #endregion
        double GetAdjustedDipoleFullLength(double adjustmentFactor, double frequency);

    }
}
