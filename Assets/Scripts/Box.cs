using UnityEngine;

[RequireComponent(typeof(Spawner))]
[RequireComponent(typeof(Rigidbody))]

public class Box : MonoBehaviour
{
    [SerializeField] private float _spawnChance = 200;
    [SerializeField] private float _reduction = 2f;

    [field: SerializeField] public float ExplosionRadius { get; private set; }
    [field: SerializeField] public float ExplosionForce { get; }

    public float SpawnChance { get { return _spawnChance; } }

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
        ExplosionRadius /= _reduction;
    }

    public Rigidbody GetRigidbody()
    {
        return GetComponent<Rigidbody>();
    }
}