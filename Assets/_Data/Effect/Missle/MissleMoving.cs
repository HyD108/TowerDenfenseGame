using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleMoving : BulletMovingAbstract
{
    public float speed = 5f;
    protected override void Moving()
    {
        transform.parent.Translate(this.speed * Time.deltaTime * Vector3.left);

    }
}
