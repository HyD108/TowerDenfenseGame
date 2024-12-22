using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesUI : Text3DAbstact
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
