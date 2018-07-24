using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorResistorCalculator.Models
{
    public class ResistanceCalculator : IOhmValueCalculator
    {


        /* <summary> 
           Calculates the minimum, maximum, and resistor value
           </summary>
        
            <param name="bandAColor">The color of the firesult figure of component value band.</param>
            <param name="bandBColor">The color of the second significant figure band.</param>
            <param name="bandCColor">The color of the decimal multiplier band.</param>
            <param name="bandDColor">The color of the tolerance value band.</param>
            <returns>A custom object the contains the calculated values for min, max and resistor ohms </returns>
        */
         
        public ResistorCaculatedValue CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
    {
        //Intialize color-code dictionary 
            ResistorMultiplier ohmInput = new ResistorMultiplier();

        //get color codes from the dictionaries
        int ohmValue = Convert.ToInt32(string.Format("{0}{1}", ohmInput.twoMainBandColors[bandAColor], ohmInput.twoMainBandColors[bandBColor]));
        int multiplier = ohmInput.multiplier[bandCColor];
        double tolerance = ohmInput.tolerance[bandDColor];

        // actual computation for the min, max and resistor based on the band parameters
        double resultMax = (ohmValue * Math.Pow(10, multiplier) * (1 + tolerance));
        double resultMin = (ohmValue * Math.Pow(10, multiplier) * (1 - tolerance));
        double resultOhmValue = (ohmValue * Math.Pow(10, multiplier));

        // save the results in ResistorCaculatedValue object
        ResistorCaculatedValue ccresult = new ResistorCaculatedValue();
        ccresult.ResistMin = Formatresult(resultMin);
        ccresult.ResistMax = Formatresult(resultMax);
        ccresult.GetSetResistor = Formatresult(resultOhmValue);

        // return resistor min, max and resistor
        return ccresult;
    }


    /// <summary>
    /// Used to format large resistance values
    /// </summary>
    /// <param name="num"> resistance value </param>
    /// <returns>formatted string of a resistance value</returns>
    public string Formatresult(double num)
    {
        //to show in Mega format 
        if (num >= 100000000)
            return (num / 1000000).ToString("#,0M") + "  Ohms";

        else if (num >= 10000000)
            return (num / 1000000).ToString("0.#") + "M  Ohms";
        //to show in Kilo format
        else if (num >= 100000)
                return (num / 1000).ToString("#,0K") + "  Ohms";

        else if (num >= 10000)
            return (num / 1000).ToString("0.#") + "K  Ohms";

        else
                return num.ToString() + "  Ohms";

    }
    }
}
