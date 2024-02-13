using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerCtrl : SaiMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner { get => junkSpawner;}
    [SerializeField] protected JunkSpawnPoints spawnPoints;
    public JunkSpawnPoints SpawnPoints { get => spawnPoints;}
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadSpawnPoints();
    }
    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
    }
    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints != null) return;
        this.spawnPoints = Transform.FindObjectOfType<JunkSpawnPoints>();
    }
}
