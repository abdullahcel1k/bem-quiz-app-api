using System;
using QuizApp.Core;
using QuizApp.Core.Helpers;
using QuizApp.Core.Models;
using QuizApp.Core.Services;
using QuizApp.Core.ViewModels;

namespace QuizApp.Services
{
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Exam> Create(Exam exam)
        {
            exam.Slug = SlugGenerator.GenerateSlug(exam.Name);
            await _unitOfWork.Exams.AddAsync(exam);
            await _unitOfWork.CommitAsync();

            return exam;
        }

        public async Task<Exam> Delete(int id)
        {
            var deletedExam = await GetById(id);
            _unitOfWork.Exams.Remove(deletedExam);
            await _unitOfWork.CommitAsync();
            return deletedExam;
        }

        public async Task<IEnumerable<Exam>> GetAll()
        {
            return await _unitOfWork.Exams.GetExamsWithQuestions();
        }

        public async Task<Exam> GetById(int id)
        {
            return await _unitOfWork.Exams.GetExamWithQuestions(id);
        }

        public async Task<ExamPageViewModel> GetExamBySlug(string slug, int order)
        {
            return await _unitOfWork.Exams.GetBySlugAsync(slug, order);
        }
    }
}

