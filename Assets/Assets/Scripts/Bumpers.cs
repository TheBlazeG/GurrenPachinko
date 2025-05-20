using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bumpers : MonoBehaviour
{
    [SerializeField]int bumperForce = 100;
    GameObject ball;
    Vector3 multiplier = new Vector3(-0.05f,-.05f,-.05f);
    Vector3 scale;
    AudioSource audioSource;
    private void Awake()
    {
        scale = transform.localScale;
        audioSource= GetComponent<AudioSource>();
    }
    private void Update()
    {
        Mathf.Clamp(transform.localScale.x, transform.localScale.x + multiplier.x, transform.localScale.x - multiplier.x);
        Mathf.Clamp(transform.localScale.y, transform.localScale.y + multiplier.x, transform.localScale.y - multiplier.x);
        Mathf.Clamp(transform.localScale.z, transform.localScale.z + multiplier.x, transform.localScale.z - multiplier.x);
        transform.localScale = scale;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
           
            
            ball = collision.gameObject;
          ball.GetComponent<Rigidbody>().AddExplosionForce(bumperForce,transform.position,1.5f);
            StartCoroutine(Bump());
            audioSource.Play();
        }
    }

    IEnumerator Bump()
    {
        
       scale -= multiplier;
       yield return new WaitForSeconds(.1f);
        
        scale += multiplier;
       
    }
}
