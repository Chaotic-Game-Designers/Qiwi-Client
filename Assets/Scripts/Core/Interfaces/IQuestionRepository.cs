using System.Collections.Generic;
using System.Threading.Tasks;

public interface IQuestionRepository
{
    MusicQuestion GetRandomQuestion();
    List<MusicQuestion> GetAllQuestions();
    Task InitializeQuestions();
}