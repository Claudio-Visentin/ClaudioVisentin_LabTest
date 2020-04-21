using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CarAI : MonoBehaviour
{
    public Transform target;
    public GameObject[] lights;
    List<GameObject> greens = new List<GameObject>();
    public float speed;
    public bool choosenext = true;
    public float rotationspeed;
    void Start()
    {
        //Sets the car's colour and sets the first target
        lights = GameObject.FindGameObjectsWithTag("Light");
        GetComponent<MeshRenderer>().material.color = Color.magenta;
        NextGoal();
    }

    void NextGoal ()
    {
        //Re-calculates how many green lights are on at the moment
        choosenext = false;
        target = null;
        greens.Clear();
        foreach (GameObject item in lights)
        {
            if (item.GetComponent<LightStateMachine>().state == "Green")
            {
                greens.Add(item);
            }
        }
        if (greens.Count != 0)
        {
            //Chooses one green light out of all available ones
            int next = Random.Range(0, greens.Count);
            //Sets it as next target
            target = greens[next].transform;
        }
        choosenext = true;
    }
    void FixedUpdate()
    {
        if (target != null && target.gameObject.GetComponent<LightStateMachine>().state == "Green")
        {
            //If the car has a target, it will move and rotate towards it
            Debug.DrawLine(transform.position, target.position, Color.red);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            var rotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), Time.deltaTime * speed);
            //If target is reached, the car will pick a new one
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                if (choosenext == true)
                {
                    NextGoal();
                }
            }
        }
        //If the target changes colour before it's reached, it will pick a new one
        else if (target == null || target.gameObject.GetComponent<LightStateMachine>().state != "Green")
        {
            if (choosenext == true)
            {
                NextGoal();
            }

        }
        //In the rare case all lights are yellow or red, it will wait for a few seconds and try again
        else
        {
            StartCoroutine("Wait");
        }
    }
        IEnumerator Wait ()
        {
            yield return new WaitForSeconds(3f);
            NextGoal();
        }
}
