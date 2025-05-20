using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTray : MonoBehaviour
{ public Stack<GameObject> balls;
   [SerializeField] GameObject ballPrefab;
    public static BallTray instance;

    // Start is called before the first frame update
    void Start()
    {
    balls = new Stack<GameObject>();
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&Score.Instance.money>=100)
        {
            Score.Instance.money -= 100;
            balls.Push(Instantiate(ballPrefab, transform.position, Quaternion.identity));
        }
    }
}
