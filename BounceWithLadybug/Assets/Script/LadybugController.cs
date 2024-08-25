using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LadybugController : MonoBehaviour
{
    float angle;
    Vector2 target, mouse;

    public float speed;
    bool isTouchLeft;
    bool isTouchRight;

    public GameObject ball;
    Vector3 pos;

    private void Start()
    {
        target = transform.position;
    }
    private void Update()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle - 15, Vector3.forward);

        float h = 0;       
        if ((isTouchLeft && h == -1) || (isTouchRight && h == 1))
        {
            h = 0;
        }
        Vector3 playerPos = this.transform.position;
        Vector3 movePos = new Vector3(mouse.x, mouse.y, 0) * speed * Time.deltaTime/2;
        this.transform.position = playerPos + movePos;

        pos = this.gameObject.transform.position;

        if(pos.x>40||pos.x<-40)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(pos.y<-20||pos.y>20)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != ("Goal"))
        {
            newObject();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Scene scene = SceneManager.GetActiveScene();
            int curScene = scene.buildIndex;
            int nextScene = curScene + 1;
            SceneManager.LoadScene(nextScene);
        }
    }
    public void newObject() //공으로 변신
    {
        Instantiate(ball, pos, Quaternion.identity);
    }
}