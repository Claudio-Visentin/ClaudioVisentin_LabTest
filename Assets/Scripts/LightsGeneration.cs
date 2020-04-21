using UnityEngine;
using System.Collections;

public class LightsGeneration : MonoBehaviour
{
    public GameObject prefab;
    public int totalobjects = 10;

    void Start()
    {
        Vector3 centerpoint = new Vector3(0f, 0f, 0f);

        for (int i = 0; i < totalobjects; i++)
        {
            Vector3 position = CreateCircle(centerpoint, 10.0f);
            Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, centerpoint - position);
            Instantiate(prefab, position, rotation);
        }
    }

    Vector3 CreateCircle(Vector3 centerpoint, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = centerpoint.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = centerpoint.y;
        pos.z = centerpoint.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}
