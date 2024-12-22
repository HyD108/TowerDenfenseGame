using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class PlayerStats : HyDBehaviour
{
    public static int Lives;
    public int startLives = 20;

    protected override void Start()
    {
        Lives = this.startLives;
        Debug.Log(Lives);
    }
}
