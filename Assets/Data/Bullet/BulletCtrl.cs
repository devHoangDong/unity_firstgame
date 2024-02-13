using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : SaiMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender { get => damageSender; }

    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn { get => bulletDespawn; }

    [SerializeField] protected Transform shooter;
    public Transform Shooter => shooter;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadBulletDespawn();
    }
    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = this.GetComponentInChildren<DamageSender>();
    }
    protected virtual void LoadBulletDespawn()
    {
        if (this.bulletDespawn != null) return;
        this.bulletDespawn = this.GetComponentInChildren<BulletDespawn>();
    }
    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }    
}
