using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spehereCollisonHandler : MonoBehaviour
{
    public spawner spawner;
    public string sphereColorTag;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(gameObject.tag))
        {
            spawner.IncreasePoints();
            Destroy(gameObject); // Destroy the current sphere on a successful match
        }
    }
}
