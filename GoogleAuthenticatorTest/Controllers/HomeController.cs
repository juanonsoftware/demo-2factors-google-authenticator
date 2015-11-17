using Google.Authenticator;
using System.Web.Mvc;

namespace GoogleAuthenticatorTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            var setupCode = tfa.GenerateSetupCode("Huan Test App", "example@gmail.com", "123456", 150, 150);

            ViewBag.QrCodeSetupImageUrl = setupCode.QrCodeSetupImageUrl;
            ViewBag.ManualEntryKey = setupCode.ManualEntryKey;

            return View();
        }

        [HttpPost]
        public ActionResult VerifyTwoFactor()
        {
            var userValue = Request.Params.Get("userValue");

            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            bool isCorrectPIN = tfa.ValidateTwoFactorPIN("123456", userValue);

            return new ContentResult()
            {
                Content = isCorrectPIN.ToString()
            };
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}