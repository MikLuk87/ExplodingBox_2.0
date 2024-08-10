using System.Collections.Generic;
using UnityEngine;

public class Exploder 
{
    public void Explod(Box box)
    {
        foreach (Rigidbody explodableObject in GetExplodableObgects(box))
            explodableObject.AddExplosionForce(box.ExplosionForce, box.transform.position, box.ExplosionRadius);
    }

    private List<Rigidbody> GetExplodableObgects(Box box)
    {
        Collider[] objects = Physics.OverlapSphere(box.transform.position, box.ExplosionRadius);

        List<Rigidbody> boxes = new();

        foreach (Collider obj in objects)
            if (obj.attachedRigidbody != null)
                boxes.Add(obj.attachedRigidbody);

        return boxes;
    }
}