using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{

    public Text txtscr;
    public GameObject panel;
    bool alive = true;
    Vector2 dir = Vector2.right;
    int scoress;
    public Text text;
    public GameObject wheelref;

    List<Transform> body = new List<Transform>();
    public GameObject body0, body1, body2, body3, body4, body5;

    void Start()
    {
        panel.SetActive(false);
        PlayerPrefs.SetInt("scored", 0);
        scoress = 0;
        text = GetComponent<Text>();
        body.Insert(0, body0.transform);
        body.Insert(1, body1.transform);
        body.Insert(2, body2.transform);
        body.Insert(3, body3.transform);
        body.Insert(4, body4.transform);
        body.Insert(5, body5.transform);
        InvokeRepeating("Move", 0.3f, 0.1f);
    }


    void Update()
    {
        if (alive)
        {
            /* // Move in a new Direction?
             if (Input.GetKey(KeyCode.RightArrow))
                 dir = Vector2.right;
             else if (Input.GetKey(KeyCode.DownArrow))
                 dir = -Vector2.up;    // '-up' means 'down'
             else if (Input.GetKey(KeyCode.LeftArrow))
                 dir = -Vector2.right; // '-right' means 'left'
             else if (Input.GetKey(KeyCode.UpArrow))
                 dir = Vector2.up;*/
            //print(wheelref.GetComponent<RectTransform>().localEulerAngles.z);
            if (wheelref.GetComponent<RectTransform>().rotation.z * 100 > 5 && PlayerPrefs.GetInt("movehelp") == 1)
            {
                print(wheelref.GetComponent<RectTransform>().localRotation.z);
                if (dir == Vector2.right)
                {
                    dir = Vector2.up;
                    PlayerPrefs.SetInt("movehelp", 0);
                }
                else if (dir == -Vector2.right)
                {
                    dir = -Vector2.up;
                    PlayerPrefs.SetInt("movehelp", 0);
                }
                else if (dir == Vector2.up)
                {
                    dir = -Vector2.right;
                    PlayerPrefs.SetInt("movehelp", 0);
                }
                else if (dir == -Vector2.up)
                {
                    dir = Vector2.right;
                    PlayerPrefs.SetInt("movehelp", 0);
                }
            }
            else if (wheelref.GetComponent<RectTransform>().rotation.z * 100 < -5 && PlayerPrefs.GetInt("movehelp") == 1)
            {
                print(wheelref.GetComponent<RectTransform>().rotation.z);
                if (dir == Vector2.right)
                {
                    dir = -Vector2.up;
                    PlayerPrefs.SetInt("movehelp", 0);
                }
                else if (dir == -Vector2.right)
                {
                    dir = Vector2.up;
                    PlayerPrefs.SetInt("movehelp", 0);
                }
                else if (dir == Vector2.up)
                {
                    dir = Vector2.right;
                    PlayerPrefs.SetInt("movehelp", 0);
                }
                else if (dir == -Vector2.up)
                {
                    dir = -Vector2.right;
                    PlayerPrefs.SetInt("movehelp", 0);
                }
            }
        }
        else {
            panel.SetActive(true);
            txtscr.text = ("Score: " +PlayerPrefs.GetInt("scored").ToString() );
        }
       
    }

    

    void Move()
    {
        if (alive)
        {

            Vector2 v = transform.position;
            transform.Translate(dir);

            body.Last().position = v;
            body.Insert(0, body.Last());
            body.RemoveAt(body.Count - 1);
        }
    }

    public void btn() {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        // Food?
        if (coll.name.StartsWith("Food"))
        {
            scoress++;Debug.Log(scoress);
            PlayerPrefs.SetInt("scored", (PlayerPrefs.GetInt("scored") + 1));
            Destroy(coll.gameObject);
            if (text)
            {
               
                text.text = "SCORE : " ;

            }
            else Debug.Log("yesss");


        }
        else if (coll.name.StartsWith("Border"))
        {
            dir = -dir;
        }
        else if (coll.name.StartsWith("poison")) {
            alive = false;
        }
    }

}