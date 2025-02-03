using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

public class GameAnalyticsService : IGameAnalyticsService
{
    private bool _isInitailized = false;

    public async Task Initialize()
    {
        if (_isInitailized) return;

        try
        {
            await UnityServices.InitializeAsync();
            await AnalyticsService.Instance.CheckForRequiredConsents();
            Debug.Log("Analytics Initialized Successfully");
            _isInitailized = true;
        }
        catch (ConsentCheckException e)
        {
            Debug.LogError($"Analytics consent check failed: {e}");
        }

    }

    public void LogGameStart()
    {
        if (!_isInitailized) return;

        var parameters = new Dictionary<string, object>
        {
            { "timestamp", System.DateTime.UtcNow },
            { "session_id", System.Guid.NewGuid().ToString() }
        };
        AnalyticsService.Instance.CustomData("game_start", parameters);
    }
}