using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Resources;
using QuizApp.Core.Models;
using QuizApp.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizApp.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize("Role")]
    public class ExamsController : Controller
    {
        private readonly IExamService _examService;
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        private readonly IUserService _userService;
        private readonly IExamSessionService _examSessionService;
        private readonly IMapper _mapper;

        public ExamsController(IExamService examService,
            IQuestionService questionService,
            IAnswerService answerService,
            IUserService userService,
            IExamSessionService examSessionService,
            IMapper mapper)
        {
            _examService = examService;
            _questionService = questionService;
            _answerService = answerService;
            _userService = userService;
            _examSessionService = examSessionService;
            _mapper = mapper;
        }

        // GET: api/exams
        [HttpGet("")]
        public async Task<ActionResult<ResponseResource>> Get()
        {
            var allExams = await _examService.GetAll();
            return Ok(ResponseResource.GenerateResponse(allExams));
        }

        // GET: api/exams/1
        [HttpGet("getDetail/{id}")]
        public async Task<ActionResult<ResponseResource>> GetDetail(int id)
        {
            var allExams = await _examService.GetById(id);
            return Ok(ResponseResource.GenerateResponse(allExams));
        }

        // GET api/exams/exam-name
        [HttpGet("startExam")]
        public async Task<ActionResult<ResponseResource>> Get(string slug, int order = 1)
        {
            var findedExam = await _examService.GetExamBySlug(slug, order);

            if (findedExam == null)
                return BadRequest(ResponseResource.GenerateResponse(null, false, "Sınav Bulunamadı!"));
            return Ok(ResponseResource.GenerateResponse(findedExam));
        }

        // POST api/exams
        [HttpPost("")]
        public async Task<ActionResult<ResponseResource>> Post([FromBody] SaveExamResource saveExam)
        {
            // TODO : validator eklenecek

            var savedExam = _mapper.Map<SaveExamResource, Exam>(saveExam);
            var addedExam = await _examService.Create(savedExam);

            var examResource = _mapper.Map<Exam, SaveExamResource>(addedExam);

            return Ok(ResponseResource.GenerateResponse(examResource));
        }

        // PUT api/exams/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/exams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseResource>> Delete(int id)
        {
            var deletedExam = await _examService.Delete(id);
            return Ok(ResponseResource.GenerateResponse(deletedExam));
        }

        [HttpPost("{id}/addquestion")]
        public async Task<ActionResult<ResponseResource>> AddQuestion(int id, [FromBody] SaveQuestionResource saveQuestion)
        {
            var savedQuestion = _mapper.Map<SaveQuestionResource, Question>(saveQuestion);
            savedQuestion.ExamId = id;
            var addedQuestion = await _questionService.AddQuestionAsync(savedQuestion);

            return Ok(ResponseResource.GenerateResponse(addedQuestion));
        }


        [HttpGet("checkAnswer")]
        public async Task<ActionResult<ResponseResource>> CheckAnswer(int answerId)
        {
            string userEmail = this.User.Claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault()?.Value;

            var user = await _userService.GetUserByEmail(userEmail);

            var addedExamSession = new ExamSession();
            addedExamSession.UserId = user.Id;
            addedExamSession.AnswerId = answerId;
            await _examSessionService.Create(addedExamSession);

            return Ok(ResponseResource.GenerateResponse(addedExamSession));
        }

        [HttpGet("completeExam")]
        public async Task<ActionResult<ResponseResource>> CompleteExam(int examId)
        {
            string userEmail = this.User.Claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault()?.Value;

            var user = await _userService.GetUserByEmail(userEmail);

         
            var correctChoiceCount = await _examSessionService.CheckExamAnswers(user.Id, examId);

            return Ok(ResponseResource.GenerateResponse(correctChoiceCount));
        }
    }
}

