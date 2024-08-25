using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBlockController : MonoBehaviour
{
    Vector3 startpos;
    public GameObject FallBlock;

    // Start is called before the first frame update
    void Start()
    {
        startpos= gameObject.transform.position;
        GameObject FallBlock = GameObject.Find("FallBlock");
    }

    // Update is called once per frame
    void Update()
    {

        //if (FallBlock.activeInHierarchy==false)
        //{
        //    Instantiate(FallBlock, startpos, Quaternion.identity);
        //}
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(FallBlock);

        if (FallBlock.activeInHierarchy == false)
        {
            Instantiate(FallBlock, startpos, Quaternion.identity);
        }

    }
}
