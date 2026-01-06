using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    // Action
    public event Action OnPlayerDie;

    public event Action<int, int> OnHpChanged;
    public event Action<int> OnCoinChanged;
    public event Action<int> OnScoreChanged;

    // Invoke Func
    public void PlayerDie() { OnPlayerDie?.Invoke(); }

    public void HpChanged(int Maxhp, int hp) { OnHpChanged?.Invoke(Maxhp, hp); }
    public void CoinChanged(int coin) { OnCoinChanged?.Invoke(coin); }
    public void ScoreChanged(int score) { OnScoreChanged?.Invoke(score); }


}
