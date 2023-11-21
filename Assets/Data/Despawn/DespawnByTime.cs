using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    protected override bool CanDespawn()
    {
        // this.distance = Vector3.Distance(transform.position, this.mainCam.position);
        // if (this.distance > this.disLimit) return true;
        return false;
    }
}
