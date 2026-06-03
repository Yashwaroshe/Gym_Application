using Microsoft.AspNetCore.Mvc;

public class BmiController : Controller
{
    [HttpGet] // 👈 IMPORTANT
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost] // 👈 IMPORTANT
    public IActionResult Index(float height, float weight)
    {
        float bmi = weight / (height * height);
        ViewBag.BMI = bmi;

        if (bmi < 18.5)
            ViewBag.Status = "Underweight";
        else if (bmi < 25)
            ViewBag.Status = "Normal";
        else if (bmi < 30)
            ViewBag.Status = "Overweight";
        else
            ViewBag.Status = "Obese";

        return View();
    }
}