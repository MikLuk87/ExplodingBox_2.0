using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Box))]

public class Spawner : MonoBehaviour
{
    private readonly int _maxRandom = 100;
    private int _minQuantity = 2;
    private int _maxQuantity = 7;

    public void Spawn(Box box)
    {
        if (Random.Range(0, _maxRandom) <= box.SpawnChance)
        {
            Rigidbody parentRb = box.GetRigidbody();

            int randomQuantity = Random.Range(_minQuantity, _maxQuantity);

            for (int i = 0; i < randomQuantity; i++)
            {
                Instantiate(parentRb, box.transform.position, box.transform.rotation);
            }
        }
        else
        {
            foreach (Rigidbody explodableObject in GetExplodableObgects())
                explodableObject.AddExplosionForce(box.ExplosionForce, transform.position, box.ExplosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObgects()
    {
        Box box = GetComponent<Box>();

        Collider[] objects = Physics.OverlapSphere(transform.position, box.ExplosionRadius);

        List<Rigidbody> boxes = new();

        foreach (Collider obj in objects)
            if (obj.attachedRigidbody != null)
                boxes.Add(obj.attachedRigidbody);

        return boxes;
    }
}