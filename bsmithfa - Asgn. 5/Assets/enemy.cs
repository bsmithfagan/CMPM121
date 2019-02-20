using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private GameObject door, player;
    public GameObject boom;
    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("Door");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.LookAt(player.transform);
        this.gameObject.GetComponent<Rigidbody>().velocity = this.transform.forward * 20;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Fire")
        {
            GameObject.Instantiate(boom, this.gameObject.transform.position, this.gameObject.transform.rotation);
            door.GetComponent<NoneShallPass>().count++;
            Object.Destroy(collision.gameObject);
            Object.Destroy(this.gameObject);
        }
    }
}
