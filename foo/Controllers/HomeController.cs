using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using stackoverflow.Restclient;
using stackoverflow.Restclient.concrete;
using Stackoverflow.Data.Dal.Repository.Abstract;
using Stackoverflow.Jwt;
using Stackoverflow.Model;
using Stackoverflow.Model.Dtos;
using Stackoverflow.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace foo.Controllers
{
    [Authorize]
    [Route("{controller}")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRest _rest;


        public HomeController(ILogger<HomeController> logger, IRest rest)
        {
            _logger = logger;
            _rest = rest;
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [Route("loginsend")]
        [HttpPost]
        public async Task<JsonResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            var res = _rest.Post("api/admin/login", userForLoginDto);


            var response = JsonConvert.DeserializeObject<UserModel>(res.Content);

            if (response.AccessToken != null)
            {
                List<Claim> claims = new List<Claim>
      {
          new Claim(ClaimTypes.Name, response.FullName),
          new Claim("id", response.ID.ToString()),
          new Claim(ClaimTypes.UserData, response.AccessToken)
      };

                // create identity  
                ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");

                // create principal  
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);


                // sign-in  
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return Json("1");
            }

            else
            {
                return Json("2");
            }
        }
        [AllowAnonymous]
        [Route("register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [Route("registersend")]
        [HttpPost]
        public JsonResult Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            var res = _rest.Post("api/admin/register", userForRegisterDto);

            var response = JsonConvert.DeserializeObject<UserModel>(res.Content);


            return Json("1");
        }

        [Route("questionview")]
        [HttpGet]
        public IActionResult SaveQuestion()
        {
            return View(new Question());
        }

        [Route("questionsend")]
        [HttpPost]
        public JsonResult SaveQuestion([FromBody] Question question)
        {
            _rest.Post("api/admin/question", question);
            return Json("1");
        }
        [Route("detail/{id}")]
        [HttpGet]
        public IActionResult DetailQuestion([FromRoute] int id)
        {
            var queryResult = _rest.Get<QuestionDto>($"api/admin/detail/{id}");
            return View(queryResult);
        }

        [Route("questions")]
        [HttpGet]
        public IActionResult ListQuestions()
        {
            var queryResult = _rest.GetList<Question>("api/admin/questions");

            return View(queryResult);
        }

        [Route("answersend")]
        [HttpPost]
        public JsonResult SaveAnswer([FromBody] Answer answer)
        {
            var user =
            new UserAnswerDto
            {
                UserId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == "id").Value),
                answer = answer
            };
            _rest.Post("api/admin/answer", user);
            return Json(answer.QuestionID);
        }

        [Route("delete/{answer_id}/{question_id}")]
        [HttpGet]
        public IActionResult DeleteAnswer(int answer_id, int question_id)
        {

            _rest.Delete($"api/admin/delete/{answer_id}");
            return RedirectToAction("DetailQuestion", new { id = question_id });
        }



    }
}
