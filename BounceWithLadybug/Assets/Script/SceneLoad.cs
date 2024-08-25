using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void StartMainScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        int curScene = scene.buildIndex;
        int nextScene = curScene + 1;
        SceneManager.LoadScene(nextScene);
    }
    public void Stage1_down()
    {
        SceneManager.LoadScene(2);
    }
    public void Stage2_down()
    {
        SceneManager.LoadScene(3);
    }
    public void Stage3_down()
    {
        SceneManager.LoadScene(4);
    }
    public void Stage4_down()
    {
        SceneManager.LoadScene(5);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //k������ ����ȭ������
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene(0);
        }
        //j ����� �ٽ�
        if (Input.GetKeyDown(KeyCode.J))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
