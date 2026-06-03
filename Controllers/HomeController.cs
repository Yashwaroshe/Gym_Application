using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using WebApplication1.Models;

namespace WebApplication1.Controllers


{
    public class HomeController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Contact(string name, string email, string message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("yourgmail@gmail.com");
                mail.To.Add("yourgmail@gmail.com");
                mail.Subject = "Contact Form";
                mail.Body = $"Name: {name}\nEmail: {email}\nMessage: {message}";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("yourgmail@gmail.com", "your_app_password");
                smtp.EnableSsl = true;

                smtp.Send(mail);

                ViewBag.Msg = "Message Sent Successfully!";
            }
            catch
            {
                ViewBag.Msg = "Error sending message!";
            }

            return View();
        }
        public IActionResult Index() => View();
        public IActionResult About() => View();
        public IActionResult Services() => View();
        public IActionResult Contact1() => View();
    }
}
















