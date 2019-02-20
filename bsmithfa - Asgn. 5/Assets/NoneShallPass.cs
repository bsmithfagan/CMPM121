using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoneShallPass : MonoBehaviour
{
    public int count, total;
    public GameObject enemy;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        total = Mathf.CeilToInt(Random.Range(10.1f, 19.9f));
        for(int x = 0; x < total; x++)
        {
            GameObject.Instantiate(enemy, new Vector3(Random.Range(-20f, 20f), 1, Random.Range(0f, 20f)), Quaternion.Euler(0, Random.Range(0f, 360f), 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= total)
        {
            animator.SetBool("open", true);
        }
    }
}
