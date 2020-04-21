using UnityEngine;

public class LightsGeneration : MonoBehaviour
{
    public GameObject prefab;
    public int totalobjects = 10;

    void Awake()
    {
        //Sets the center of the circle
        Vector3 centerpoint = new Vector3(0f, 0f, 0f);

        //Divides the circle in 10 parts and equally places the lights
        for (int i = 0; i < totalobjects; i++)
        {
            float angle = i * Mathf.PI * 2f / 10;
            Vector3 newPosition = new Vector3(Mathf.Cos(angle) * 10, 0, Mathf.Sin(angle) * 10);
            _ = Instantiate(prefab, newPosition, Quaternion.identity);
        }
    }
}
