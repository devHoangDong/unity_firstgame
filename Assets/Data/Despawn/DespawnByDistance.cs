using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform mainCam;
    
    protected override void LoadComponents()
    {
        this.LoadCamera();
    }
    protected virtual void LoadCamera()
    {
        if (this.mainCam != null) return;
        this.mainCam = Transform.FindObjectOfType<Camera>().transform;
    }
    protected override void Despawning()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObject();
    }
    public override void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }
    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, this.mainCam.position);
        if (this.distance > this.disLimit) return true;
        return false;
    }
    protected override void FixedUpdate()
    {
        this.Despawning();
    }
}
