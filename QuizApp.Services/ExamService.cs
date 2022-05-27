using System;
using QuizApp.Core;
using QuizApp.Core.Helpers;
using QuizApp.Core.Models;
using QuizApp.Core.Services;

namespace QuizApp.Services
{
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Exam> CreateExam(Exam exam)
        {
            exam.Slug = SlugGenerator.GenerateSlug(exam.Name);
            await _unitOfWork.Exams.AddAsync(exam);
            await _unitOfWork.CommitAsync();

            return exam;
        }

        public async Task<IEnumerable<Exam>> GetAll()
        {
            return await _unitOfWork.Exams.GetAllAsync();
        }

        public async Task<Exam> GetExamBySlug(string slug)
        {
            return await _unitOfWork.Exams.SingleOrDefaultAsync(x => x.Slug == slug);
        }
    }
}

