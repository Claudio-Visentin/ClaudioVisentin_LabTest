using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour
{
    public Transform target;
    public GameObject[] lights;
    List<GameObject> greens = new List<GameObject>();
    public float speed;
    bool choosenext = true;
    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("Light");
        GetComponent<MeshRenderer>().material.color = Color.magenta;
        NextGoal();
    }

    void NextGoal ()
    {
        target = null;
        greens.Clear();
        foreach (GameObject item in lights)
        {
            if (item.GetComponent<LightStateMachine>().state == "Green")
            {
                greens.Add(item);
            }
        }
        int next = Random.Range(0, greens.Count);
        target = greens[next].transform;
        choosenext = true;
    }
    void FixedUpdate()
    {
        if (target != null && target.gameObject.GetComponent <LightStateMachine> ().state == "Green")
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            if (Vector3.Distance (transform.position, target.position) < 0.1f)
            {
                if (choosenext == true)
                {
                    NextGoal();
                    choosenext = false;
                }
            }
        } 
        else
        {
            if (choosenext == true)
            {
                NextGoal();
                choosenext = false;
            }

        }
    }
}
