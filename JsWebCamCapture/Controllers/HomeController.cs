using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace JsWebCamCapture.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public void SendEmail(string base64text)
        {


            var fromAddress = new MailAddress("from@gmail.com", "From Name");
            var toAddress = new MailAddress("to@example.com", "To Name");
            const string fromPassword = "fromPassword";
            const string subject = "Subject";
            const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }


        [HttpPost]

        public void SaveImage(string base64image)
            {
            if (string.IsNullOrEmpty(base64image))
                return;

            //Just use this base64image code as src of image and you can see the taken image
            try
            {

                SendEmail(base64image);
                //using (var w = new StreamWriter(Server.MapPath("~/Content/Images/" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss"))+".txt"))
                //{
                //    w.WriteLine(base64image);
                //}
            }
            catch (Exception ex)
            {

              
            }
           
           
        }
    }
}