using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stackoverflow.Data.Dal.Repository.Abstract;
using Stackoverflow.Jwt;
using Stackoverflow.Model;
using Stackoverflow.Model.Dtos;
using Stackoverflow.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stackoverflow_api.Controllers
{
    
    [Route("api/{controller}")]
    [ApiController]
    public class AdminController : Controller
    {
        private IAuthService _authservice;

        private readonly IRepository<Question> _repository_question;

        private readonly IRepository<Answer> _repository_answer;

        private readonly IRepository<User> _repository_user;

        private readonly IRepository<UserAnswer> _repository_user_answer;

        public AdminController(IAuthService authservice, IRepository<Question> repository_question, IRepository<Answer> repository_answer, IRepository<User> repository_user, IRepository<UserAnswer> repository_user_answer)
        {
            _authservice = authservice;
            _repository_question = repository_question;
            _repository_answer = repository_answer;
            _repository_user = repository_user;
            _repository_user_answer = repository_user_answer;
        }
        
        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authservice.Login(userForLoginDto);
            var accesstoken = _authservice.CreateAccessToken(userToLogin);
            if (userToLogin != null)
            {
                return Ok(new UserModel { FullName = userToLogin.FullName, ID = userToLogin.ID, AccessToken = accesstoken.Token });

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var registerResult = _authservice.Register(userForRegisterDto, userForRegisterDto.Password);

            var id = _repository_user.Find(u => u.Email == userForRegisterDto.Email).ID;
            var fullname = _repository_user.Find(u => u.Email == userForRegisterDto.Email).UserName;
            var result = _authservice.CreateAccessToken(registerResult);
            return Ok(new UserModel { FullName = fullname, ID = id, AccessToken = result.Token });
        }

        [HttpPost("question")]
        public IActionResult SaveQuestion([FromBody] Question question)
        {
            question.CreatedAt = DateTime.Now;
            _repository_question.Add(question);
            _repository_question.Save();
            return Ok();
        }

        [HttpGet("questions")]
        public List<Question> SendQuestions()
        {
            var questions = _repository_question.GetList().ToList();
            return questions;
        }

        [HttpPost("answer")]
        public IActionResult SaveAnswer([FromBody] UserAnswerDto answerUser)
        {
            answerUser.answer.CreatedAt = DateTime.Now;
            _repository_answer.Add(answerUser.answer);
            _repository_answer.Save();

            var userAnswer = new UserAnswer { UserID = answerUser.UserId, CreatedAt = DateTime.Now, AnswerID = answerUser.answer.ID };
            _repository_user_answer.Add(userAnswer);
            _repository_user_answer.Save();
            return Ok();
        }


        [Route("detail/{id}")]
        [HttpGet]
        public QuestionDto DetailQuestion([FromRoute] int id)
        {
            var question = _repository_question.Table().Include(c => c.Answers).Where(c => c.ID == id).Select(x => new QuestionDto
            {
                Title = x.Title,
                Content = x.Content,
                Slug = x.Slug,
                UserID = x.UserID,
                CreatedAt = x.CreatedAt,
                ID = x.ID,
                answers = x.Answers.Select(y => new AnswerDto
                {
                    ID = y.ID,
                    CreatedAt = y.CreatedAt,
                    QuestionID = y.QuestionID,
                    TextField = y.TextField
                }).ToList()
            }).FirstOrDefault();
            return question;
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteAnswer([FromRoute] int id)
        {
            var answer = _repository_answer.Table().Where(x => x.ID == id).FirstOrDefault();
            _repository_answer.Delete(answer);
            return Ok(answer.QuestionID);
        }


    }
}
