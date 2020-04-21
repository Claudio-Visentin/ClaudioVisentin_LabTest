using System.Collections;
using UnityEngine;

public class LightStateMachine : MonoBehaviour
{
    public string state;
    Material mat;
    void Awake()
    {
        //Sets up the material
        mat = GetComponent<MeshRenderer>().material;

        //Randomly picks the first colour
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
    //Each coroutine leads to the next one and loops, setting the required states
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
