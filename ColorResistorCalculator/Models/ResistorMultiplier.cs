using System.Collections.Generic;

namespace ColorResistorCalculator.Models
{
    public class ResistorMultiplier
    {
        // Dictionary for Band A and Band B for computation
        public Dictionary<string, int> twoMainBandColors;
        // Dictionary for Band C used as the multiplier computation
        public Dictionary<string, int> multiplier;
        // Dictionary for Band D for the tolerance computation
        public Dictionary<string, double> tolerance;

        //Empty Constructor 
        public ResistorMultiplier()
        {
            // Initialize the dictionary for Band A & B
            twoMainBandColors = new Dictionary<string, int> {
                    {"black", 0},
                    {"brown", 1},
                    {"red", 2},
                    {"orange", 3},
                    {"yellow", 4},
                    {"green", 5},
                    {"blue", 6},
                    {"violet", 7},
                    {"gray", 8},
                    {"white", 9}
            };
            // Initialize the dictionary for Band C - Multiplier
            multiplier = new Dictionary<string, int> {
                    {"pink", -3},
                    {"silver",  -2},
                    {"gold",  -1},
                    {"black", 0},
                    {"brown", 1},
                    {"red", 2},
                    {"orange",3},
                    {"yellow", 4},
                    {"green", 5},
                    {"blue",  6},
                    {"violet", 7},
                    {"gray", 8},
                    {"white", 9}
            };

            //  Initialize the dictionary for Band D - Tolerance Min and Max
            tolerance = new Dictionary<string, double> {
                    {"silver", 0.10},
                    {"gold", 0.05},
                    {"brown",  0.01},
                    {"red", 0.02},
                    {"yellow", 0.05},
                    {"green", 0.005},
                    {"blue", 0.0025},
                    {"violet", 0.001},
                    {"gray", 0.0005}
            };

        }

    }
}
