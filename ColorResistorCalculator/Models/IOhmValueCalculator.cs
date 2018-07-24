using System;

namespace ColorResistorCalculator.Models
{
    public interface IOhmValueCalculator
    {
        /* <summary> 
           Calls the CalculateOhmValue that calculates the minimum, maximum, and resistor value
           </summary>
        
            <param name="bandAColor">The color of the firesult figure of component value band.</param>
            <param name="bandBColor">The color of the second significant figure band.</param>
            <param name="bandCColor">The color of the decimal multiplier band.</param>
            <param name="bandDColor">The color of the tolerance value band.</param>
            <returns>Returns a JSON response that contains the resistor values for min, max and resistor </returns>
        */

        ResistorCaculatedValue CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);
    }
}
