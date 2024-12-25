using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCountDownTimer : TextAbstact
{
    [SerializeField] protected EnemyWave wave;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWave(); 

    }
    private void Update()
    {
        this.LoadTimeSpawn();
    }

    private void LoadWave()
    {
        if (this.wave != null) return;
        this.wave = FindAnyObjectByType<EnemyWave>();
    }
    protected virtual void LoadTimeSpawn()
    {

        this.textPro.text = string.Format("{0:0.00}", wave.CountDown);
    }
}
