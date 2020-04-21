using System.Collections;
using UnityEngine;

public class LightStateMachine : MonoBehaviour
{
    public string state;
    Material mat;
    void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;

        int firststate = Random.Range(0, 3);
        if (firststate == 0)
        {
            StartCoroutine("Green");
        }
        if (firststate == 1)
        {
            StartCoroutine("Yellow");
        }
        if (firststate == 2)
        {
            StartCoroutine("Red");
        }
    }
    IEnumerator Green ()
    {
        state = "Green";
        mat.color = Color.green;
        yield return new WaitForSeconds(Random.Range(5, 11));
        StartCoroutine("Yellow");
    }
    IEnumerator Yellow ()
    {
        state = "Yellow";
        mat.color = Color.yellow;
        yield return new WaitForSeconds(4f);
        StartCoroutine("Red");
    }
    IEnumerator Red ()
    {
        state = "Red";
        mat.color = Color.red;
        yield return new WaitForSeconds(Random.Range(5, 11));
        StartCoroutine("Green");
    }
    
}
