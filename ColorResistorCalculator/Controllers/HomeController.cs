using System;
using Microsoft.AspNetCore.Mvc;
using ColorResistorCalculator.Models;

namespace ColorResistorCalculator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            try
            {
                //Fill in the selector for Band A, Band B, Band C and Band D
                ResistorColorSelector loadSelect = new ResistorColorSelector();

                //Return the index view - User Interface for the resistor calculator
                return View(loadSelect);
            }
            catch (Exception ex)
            {
                // if exception then return error as response 
                return Json(new { error = "Exception ocurred while loading select controls: " + ex.Message });
            }
        }

       
        [HttpPost]
        public ActionResult getResistanceValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            try
            {

                // Initializing the Object
                IOhmValueCalculator objResistance = new ResistanceCalculator();

                // Calling the method that calculates the resistor value 
                ResistorCaculatedValue resultObject = objResistance.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

                /// Returning the JSON response
                return Json(new { min = resultObject.ResistMin, max = resultObject.ResistMax, main = resultObject.GetSetResistor });
            }
            catch (Exception ex)
            {
                // Return an error if there's an exception 
                return Json(new { error = "Exception ocurred while calculating resistance value: " + ex.Message });
            }
        }
    }
}
