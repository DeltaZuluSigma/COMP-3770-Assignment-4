using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Bubble bubble;
    private Bubble clone;
    //spawn position
    private Vector3 spawnPos;
    // to determine which directions bubbles will spawn
    public bool down;
    public bool right;
    public bool left;
    public bool up;
    // counters for missed and popped from this spawner
    public int nPopped;
    public int nMissed;
    // speed var
    public float speed;
    //stop spawns
    public bool disabled;
    

    // Start is called before the first frame update
    void Start()
    {
        disabled = false;
        spawnBubble();

        nPopped = 0;
        nMissed = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (disabled == false)
        {
            if (clone.isPopped == true)
            {
                nPopped += 1;
                Destroy(this.clone.gameObject);
                spawnBubble();
                clone.isPopped = false;
            }
            else moveBubble();

            if (clone.isMissed == true)
            {
                nMissed += 1;
                Destroy(this.clone.gameObject);
                spawnBubble();
                clone.isMissed = false;
            }
            else moveBubble();
        }
    }
    public void spawnBubble()
    {
        spawnPos = this.transform.position;
        clone = Instantiate(bubble);
        clone.transform.position = spawnPos;
    }

    public void moveBubble()
    {
        if (down == true)
            clone.transform.position += Vector3.down * speed * Time.deltaTime;
        if (up == true)
            clone.transform.position += Vector3.up * speed * Time.deltaTime;
        if (right == true)
            clone.transform.position += Vector3.right * speed * Time.deltaTime;
        if (left == true)
            clone.transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
