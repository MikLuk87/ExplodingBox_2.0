using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Painter : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, Random.value);
    }
}