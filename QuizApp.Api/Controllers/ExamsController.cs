using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Resources;
using QuizApp.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class ExamsController : Controller
    {
        private readonly IExamService _examService;
        private readonly IMapper _mapper;

        public ExamsController(IExamService examService, IMapper mapper)
        {
            _examService = examService;
            _mapper = mapper;
        }

        // GET: api/exams
        [HttpGet("")]
        public async Task<ActionResult<ResponseResource>> Get()
        {
            var allExams = await _examService.GetAll();
            return Ok(ResponseResource.GenerateResponse(allExams));
        }

        // GET api/exams/exam-name
        [HttpGet("{slug}")]
        public async Task<ActionResult<ResponseResource>> Get(string slug)
        {
            var findedExam = await _examService.GetExamBySlug(slug);

            if (findedExam == null)
                return BadRequest(ResponseResource.GenerateResponse(null, false, "Sınav Bulunamadı!"));
            return Ok(ResponseResource.GenerateResponse(findedExam));
        }

        // POST api/exams
        [HttpPost("")]
        public async Task<ActionResult<ResponseResource>> Post([FromBody] SaveExamResource saveExam)
        {
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

