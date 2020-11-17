using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
    Ray myRay;
    RaycastHit hit;

    public GameObject Yellow;
    public GameObject Blue;
    public GameObject Green;
    public GameObject Red;
    public GameObject objectToInstantiate;
    public float waitTime = 0.1f;
    
    private float timeStamp = Mathf.Infinity;
    private Stack<GameObject> spheres = new Stack<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        myRay = Camera.main.ScreenPointToRay (Input.mousePosition);
        if (Physics.Raycast (myRay, out hit)) { 
            if (hit.transform.name == "Yellow" && Input.GetMouseButtonDown (0))
            {
                objectToInstantiate = Yellow;
            }
            else if (hit.transform.name == "Red" && Input.GetMouseButtonDown (0))
            {
                objectToInstantiate = Red;
            }
            else if (hit.transform.name == "Blue" && Input.GetMouseButtonDown (0))
            {
                objectToInstantiate = Blue;
            }
            else if (hit.transform.name == "Green" && Input.GetMouseButtonDown (0))
            {
                objectToInstantiate = Green;
            }
            else if (Input.GetMouseButtonDown (0) && hit.transform.name == "Canvas") {
                GameObject sphere = Instantiate (objectToInstantiate, hit.point, Quaternion.identity);
                spheres.Push(sphere);
            }                            
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            timeStamp = Time.time + waitTime;
        }
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            timeStamp = Mathf.Infinity;
        }

        if (Time.time >= timeStamp)
        {
            if (Input.GetMouseButton(1) && spheres.Count > 0)
            {
                Destroy(spheres.Pop().gameObject);
                timeStamp = Time.time + waitTime;
            }
            else if (Input.GetMouseButton(0)  && hit.transform.name == "Canvas" && hit.transform.name != "Yellow" && hit.transform.name != "Blue" && hit.transform.name != "Green" && hit.transform.name != "Red")
            {
                GameObject sphere = Instantiate (objectToInstantiate, hit.point, Quaternion.identity);
                spheres.Push(sphere);
                timeStamp = Time.time + waitTime;
            }
        }
    }
}
