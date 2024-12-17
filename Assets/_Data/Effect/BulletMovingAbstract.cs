using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletMovingAbstract : HyDBehaviour
{

    protected virtual void Update()
    {
        this.Moving();
    }

    protected abstract void Moving();
    
}
