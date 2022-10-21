using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemiAI : MonoBehaviour
{
    public GameObject player;
    public Vector3 dir;
    public float agroRadius = 15.0f;

    private bool xOrY = false;
    private int rndVlue = 0;

    // Start is called before the first frame update
    void Start()
    {
        new Thread(tick).Start();
    }

    // Update is called once per frame
    void Update()
    {
        rndVlue = Random.Range(0, 100);
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        dir = player.transform.position - transform.position;
        if (dir.magnitude < agroRadius)
        {
            dir = new Vector3(dir.x + Mathf.Sin(Time.time) * 5, dir.y - Mathf.Sin(Time.time) * 5, 0);
            transform.Translate((dir.normalized) * Time.deltaTime * gameObject.GetComponent<MagicRenderer>().speed);
        }
    }

    private void tick()
    {
        while (true)
        {
            xOrY = rndVlue % 2 == 0 ? true : false;
            Thread.Sleep(1000);
        }
    }
}
