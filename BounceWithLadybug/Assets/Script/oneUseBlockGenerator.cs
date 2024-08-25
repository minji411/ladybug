using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oneUseBlockGenerator : MonoBehaviour
{
    Vector2 mouse;
    public GameObject oneUse;
    public RectTransform transform_icon;
    public Text count;
    int Bcount = 3;

    void Start()
    {
        count = GameObject.Find("BlockCount").GetComponent<Text>();

        if (transform_icon.GetComponent<Graphic>())
            transform_icon.GetComponent<Graphic>().raycastTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        Update_MousePosition();
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonUp(0))
        {
            if (Bcount > 0)
            {
                Instantiate(oneUse, mouse, Quaternion.identity);
                Bcount--;
                count.text = " : " + Bcount.ToString();
            }
        }
        if (Bcount <= 0)
        {
            transform_icon.gameObject.SetActive(false);
        }
    }

    private void Update_MousePosition()
    {
        Vector2 mousePos = Input.mousePosition;
        float w = transform_icon.rect.width;
        float h = transform_icon.rect.height;
        transform_icon.position = mousePos + (new Vector2(w, h) * 0f);
    }
}