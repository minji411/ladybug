using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public float speed;

    Rigidbody2D rigid2D;
    float jumpForce = 550f;

    int item = 0;
    public GameObject obj;
    Vector3 pos;
    Vector3 startpos;

    //한뱡향
    bool isright;
    public float rightspeed;

    //효과음
    AudioSource audioSource;
    public AudioClip AudioBounce;
    public AudioClip AudioItem;
    public AudioClip AudioOneBlock;
    

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.audioSource = GetComponent<AudioSource>();

    }
    void Update()
    {
        Vector3 playerPos = this.transform.position;
        //이동
        if (!isright)
        {
            rigid2D.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rigid2D.velocity.y);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.D))
            {
                isright = false; 
                rigid2D.gravityScale = 2;
            }
            
        }
     
        //아이템 다 먹으면 변신
        if (item == 3)
        {
            newObject();
            Destroy(gameObject);
            item = 0;
        }
        pos = this.gameObject.transform.position;

        if(pos.y<-30) //떨어지면 다시
        {  
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            PlaySound("Item");
            item++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Goal")
        {
            Scene scene = SceneManager.GetActiveScene();
            int curScene = scene.buildIndex;
            int nextScene = curScene + 1;
            SceneManager.LoadScene(nextScene);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 dir = collision.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (angle <= -15 && angle >= -170) //-15 -170
        {
            if (collision.gameObject.tag == "Block") //일반블럭에 부딫힐때 
            {
                this.rigid2D.AddForce(transform.up * this.jumpForce);
                PlaySound("Bounce");

            }
            switch (collision.collider.tag)
            {
                case "Jump":  //점프강화
                    this.rigid2D.AddForce(transform.up * (this.jumpForce + 250f));
                    PlaySound("Bounce");
                    break;
                case "Right":  //한방향블럭
                    ShootingOn(new Vector2(collision.transform.localScale.x, 0), collision.transform.position);
                    PlaySound("Bounce");
                    break;
                case "OneUse":  //일회용블럭
                    this.rigid2D.AddForce(transform.up * this.jumpForce);
                    PlaySound("One");
                    break;

            }
        }
     
        if(collision.gameObject.tag=="Spike")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void ShootingOn(Vector2 dir, Vector2 pos) //한방향블럭
    {
        isright = true;
        rigid2D.gravityScale = 0;
        transform.position = pos + dir;
        rigid2D.velocity = dir * rightspeed;
    }
  
    public void newObject()
    {
        Instantiate(obj, pos, Quaternion.identity);
    }

    void PlaySound(string action)
    {
        switch(action)
        {
            case "Bounce":
                audioSource.clip = AudioBounce;
                break;
            case "Item":
                audioSource.clip = AudioItem;
                break;
            case "One":
                audioSource.clip = AudioOneBlock;
                break;
        
        }
        audioSource.Play();
    }
}