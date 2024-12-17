using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoving : BulletMovingAbstract
{
    public float speed = 20f;

   protected override void Moving()
    {
        transform.parent.Translate(this.speed * Time.deltaTime * Vector3.forward);
    }
}
