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
            Rigidbody parentRigidbody = box.GetRigidbody();

            int randomQuantity = Random.Range(_minQuantity, _maxQuantity);

            for (int i = 0; i < randomQuantity; i++)
            {
                Instantiate(parentRigidbody, box.transform.position, box.transform.rotation);
            }
        }
        else
        {
            Exploder exploder = new();

            exploder.Explod(box);
        }
    }
}