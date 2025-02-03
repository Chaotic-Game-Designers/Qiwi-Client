using System.Threading.Tasks;

public interface IGameAnalyticsService
{
    Task Initialize();
    void LogGameStart();
}