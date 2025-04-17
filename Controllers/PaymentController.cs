//using Microsoft.AspNetCore.Mvc;
//using Razorpay.Api;
//using System;
//using System.Collections.Generic;

//namespace YourProject.Controllers
//{
//    public class PaymentController : Controller
//    {
//        [HttpGet]
//        public IActionResult Checkout(int courseId)
//        {
//            // Retrieve course details from the database (e.g., price, course name, etc.)
//            var course = _courseService.GetCourseById(courseId); // Example service to fetch course details

//            if (course == null)
//            {
//                return NotFound();
//            }

//            ViewBag.Course = course; // Passing course details to the view
//            return View();
//        }

//        [HttpPost]
//        public IActionResult CreateOrder(int courseId)
//        {
//            var course = _courseService.GetCourseById(courseId); // Fetch course details by ID
//            if (course == null)
//            {
//                return NotFound();
//            }

//            RazorpayClient client = new RazorpayClient("YOUR_KEY_ID", "YOUR_KEY_SECRET");

//            Dictionary<string, object> options = new Dictionary<string, object>();
//            options.Add("amount", course.Price * 100); // Price in paise
//            options.Add("currency", "INR");
//            options.Add("receipt", "order_rcptid_" + courseId);
//            options.Add("payment_capture", 1);

//            Order order = client.Order.Create(options);
//            ViewBag.OrderId = order["id"].ToString();
//            ViewBag.Key = "YOUR_KEY_ID";
//            ViewBag.Amount = course.Price * 100; // Price in paise

//            return View("PaymentPage");
//        }

//        [HttpPost]
//        public IActionResult PaymentSuccess(string razorpay_payment_id, string razorpay_order_id, string razorpay_signature)
//        {
//            // Save payment info to the database (if necessary)
//            ViewBag.PaymentId = razorpay_payment_id;
//            return View("Success");
//        }
//    }
//}
