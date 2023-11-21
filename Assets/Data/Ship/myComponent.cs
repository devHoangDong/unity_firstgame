using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myComponent : MonoBehaviour
{
    [SerializeField] protected Vector3 worldPosition;
    [SerializeField] protected float speed = 0.1f;

    void FixedUpdate()
    {
        this.GetTargetPosition();
        this.LookAtTarget();
        this.Moving();
        
    }
   
    protected virtual void GetTargetPosition()
    {
        this.worldPosition = InputManager.Instance.MouseWorldPos;
        this.worldPosition.z = 0;
    }
     protected virtual void LookAtTarget()
    {
       Vector3 diff = this.worldPosition - transform.parent.position;
       diff.Normalize();
       float rot_z = Mathf.Atan2(diff.y, diff.x)*Mathf.Rad2Deg;
       transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, worldPosition, this.speed);
        transform.parent.position = newPos;
    }
}
