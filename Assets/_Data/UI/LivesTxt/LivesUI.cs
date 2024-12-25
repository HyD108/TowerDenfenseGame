using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesUI : TextAbstact
{
    private void Update()
    {
        this.LiveUpdate();
    }
    protected virtual void LiveUpdate()
    {
        this.textPro.text = PlayerStats.Lives.ToString();
    }
}
