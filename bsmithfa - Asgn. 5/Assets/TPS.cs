using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPS : MonoBehaviour
{
    private GameObject player, camera;
    public GameObject bullet;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        camera = GameObject.Find("Main Camera");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0f));
        camera.transform.RotateAround(player.transform.position, player.transform.right, Input.GetAxis("Mouse Y"));

        Vector3 speedY = player.transform.forward * Input.GetAxis("Vertical") / 10f;
        Vector3 speedX = player.transform.right * Input.GetAxis("Horizontal") / 10f;

        player.transform.position += speedY;
        player.transform.position += speedX;

        if(speedY.magnitude == 0 && speedX.magnitude == 0)
        {
            animator.SetInteger("direction", 0);
        }
        else if(Mathf.Abs(Input.GetAxis("Vertical")) >= Mathf.Abs(Input.GetAxis("Horizontal")))
        {
            animator.SetInteger("direction", Input.GetAxis("Vertical") > 0 ? 1 : 2);
        }
        else
        {
            animator.SetInteger("direction", Input.GetAxis("Horizontal") > 0 ? 4 : 3);
        }
    }

    private void OnMouseDown()
    {
        GameObject shot = GameObject.Instantiate(bullet, new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, player.transform.position.z), player.transform.rotation);
        shot.GetComponent<Rigidbody>().AddForce(player.transform.forward * 2000);
    }
}
