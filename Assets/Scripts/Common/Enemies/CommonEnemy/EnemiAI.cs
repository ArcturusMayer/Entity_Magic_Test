using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiAI : MonoBehaviour
{
    public GameObject player;
    public Vector3 dir;
    public float agroRadius = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dir = player.transform.position - transform.position;
        if (dir.magnitude < agroRadius)
        {
            dir.Normalize();
            transform.Translate(dir * Time.deltaTime * gameObject.GetComponent<MagicRenderer>().speed);
        }
    }
}
