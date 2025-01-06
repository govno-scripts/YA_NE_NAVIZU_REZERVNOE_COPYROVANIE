using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC : MonoBehaviour
{
    public int health = 5;
    public int level = 1;
    public float speed = 1.0f;
    public float rotation = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pose = transform.position;
        pose.z += speed * Time.deltaTime;
        transform.position = pose;

    }
}
