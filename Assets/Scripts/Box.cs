using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Spawner))]

public class Box : MonoBehaviour
{
    [SerializeField] private float _spawnChance = 200;
    [SerializeField] private float _reduction = 2f;
    [SerializeField] private float _explosionRadius = 32;
    [SerializeField] private float _explosionForce = 800;

    public float ExplosionRadius
    {
        get { return _explosionRadius; }
        private set { }
    }

    public float ExplosionForce
    {
        get { return _explosionForce; }
        private set { }
    }

    public float SpawnChance { get { return _spawnChance; } private set { } }

    private void OnMouseDown()
    {
        Spawner spawner = GetComponent<Spawner>();

        spawner.Spawn(this);
        Destroy(gameObject);
    }

    private void Start()
    {
        _spawnChance /= _reduction;
        transform.localScale /= _reduction;
        _explosionRadius /= _reduction;
    }

    public Rigidbody GetRigidbody()
    {
        if (GetComponent<Rigidbody>() == null)
        {
            this.AddComponent<Rigidbody>();
        }

        return GetComponent<Rigidbody>();
    }
}