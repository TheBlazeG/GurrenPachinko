using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holes : MonoBehaviour
{
    [SerializeField] int winnings;
    AudioSource winningsSource;
    // Start is called before the first frame update

    private void Start()
    {
        winningsSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Score.Instance.money += winnings;
        winningsSource.Play();
    }
}
