using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherControl : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerExit(Collider collision)
    {
       
        if (collision.gameObject.GetComponent<BallState>().launched==true)
        {
            Destroy(collision.gameObject);
        }
        collision.gameObject.GetComponent<BallState>().launched =true;
    }
    
}
