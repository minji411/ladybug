using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public GameObject BlinkBlock;
    public float myTime;
  

    // Start is called before the first frame update
    void Start()
    {
        GameObject BlinkBlock = GameObject.Find("BlinkBlock");
    }

    // Update is called once per frame
    void Update()
    {
        //½Ã°£¸¶´Ù ±ôºýÀÌ´Â ºí·°
        myTime += Time.deltaTime;
        if (myTime > 2 && myTime < 4)
        {
            BlinkBlock.gameObject.SetActive(false);
            myTime += Time.deltaTime;
        }
        if (myTime > 4)
        {
            BlinkBlock.gameObject.SetActive(true);
            myTime = 0;
        }
       
    }
  
}