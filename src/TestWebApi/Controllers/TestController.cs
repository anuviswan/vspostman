 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace TestWebApi.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public string GetPrimitiveResult(int id) => GetRandomString();

        public dynamic GetComplexResult(int id) => new { Id=2, Name = GetRandomString()};

        private string GetRandomString() => Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
    }
}