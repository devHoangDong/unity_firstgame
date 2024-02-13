using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : SaiMonoBehaviour
{
    [Header("Junk Random")]
    [SerializeField] protected JunkSpawnerCtrl junkCtrlSpawner;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 9f;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }
    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrlSpawner != null) return;
        this.junkCtrlSpawner = GetComponent<JunkSpawnerCtrl>();
    }
    
    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }
    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;
        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0;
        Transform ranPoint = this.junkCtrlSpawner.SpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;
        Transform prefab = this.junkCtrlSpawner.JunkSpawner.RandomPrefab();
        Transform obj = this.junkCtrlSpawner.JunkSpawner.SpawnNew(prefab, pos, rot);
        obj.gameObject.SetActive(true);
    }
    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.junkCtrlSpawner.JunkSpawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }
        
}
