using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallState : MonoBehaviour
{
    public bool launched = false;
    [SerializeField] AudioSource hit;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer==LayerMask.NameToLayer("Board"))
        {
            Debug.Log("hitboard");
             hit.Play();
        }
       
    }
}
