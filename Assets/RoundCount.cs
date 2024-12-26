using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundCount : TextAbstact
{
    [SerializeField] protected EnemyWave wave;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWave();

    }
    private void Update()
    {
        this.LoadRound();
    }

    private void LoadWave()
    {
        if (this.wave != null) return;
        this.wave = FindAnyObjectByType<EnemyWave>();
    }
    protected virtual void LoadRound()
    {

        this.textPro.text = this.wave.WaveIndex.ToString();
    }
}
