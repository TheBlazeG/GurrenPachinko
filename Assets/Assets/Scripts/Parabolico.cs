using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parabolico : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform launchPoint;       // Punto de lanzamiento
    public float launchAngle = 45f;     // Ángulo de lanzamiento en grados
    public float launchSpeed = 20f;     // Velocidad inicial
    public bool isIncreasing;
    public Image PowerMask;
    public float barChangeSpeed;
    float maxPowerBarValue = 50;
    float currentPowerBar;
    bool powerBarOn;
 
  


    public GameObject currentProjectile; // Referencia a la bala actual
    private void Start()
    {
        currentPowerBar = 0;
        isIncreasing = false;
        powerBarOn = false;
        
        
    }
    void Update()
    { 
       
        // Si presionamos click izquierdo y no hay una bala activa
        if (Input.GetMouseButtonDown(0) && BallTray.instance.balls.Count!=0)
        {
            powerBarOn = true;
            StartCoroutine(UpdatePowerBar());
            Destroy(BallTray.instance.balls.Peek());
            //BallTray.instance.balls.RemoveAt(0);
            BallTray.instance.balls.Pop();

        }
        if (Input.GetMouseButtonUp(0))
        {
            powerBarOn = false;
            
            
        }
    }

    void LaunchProjectile()
    {
        // Instanciar un nuevo proyectil en el punto de lanzamiento
        currentProjectile = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);

        // Obtener el Rigidbody del proyectil instanciado
        Rigidbody rb = currentProjectile.GetComponent<Rigidbody>();

        // Calcular el ángulo de lanzamiento en radianes
        float launchAngleInRadians = launchAngle * Mathf.Deg2Rad;

        // Descomponer la velocidad inicial en componentes horizontal y vertical
        float v0x = (launchSpeed+(30*PowerMask.fillAmount)) * Mathf.Cos(launchAngleInRadians); // Componente X (horizontal)
        float v0y = (launchSpeed + (30 * PowerMask.fillAmount)) * Mathf.Sin(launchAngleInRadians); // Componente Y (vertical)

        // Aplicar la velocidad inicial al Rigidbody
        Vector3 launchVelocity = new Vector3(0, v0y, v0x); // Lanzamiento en un plano 2D
        rb.velocity = launchVelocity;

        // Activar la gravedad para el proyectil
        rb.useGravity = true;
        PowerMask.fillAmount = 0;

    }
    public void HandleCollision(GameObject projectile, Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            DestroyProjectile(0f);
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("Target"))
        {
            DestroyProjectile(0f);
        }
    }
    void DestroyProjectile(float delay)
    {
        if (currentProjectile != null)
        {
            Destroy(currentProjectile, delay);
            currentProjectile = null;
        }
    }
    IEnumerator UpdatePowerBar()
    {
        while (powerBarOn) {  
            currentPowerBar += barChangeSpeed;
        float fill = currentPowerBar / maxPowerBarValue;
        PowerMask.fillAmount = fill;
        yield return new WaitForSeconds(0.02f);}
       currentPowerBar = 0f;
        LaunchProjectile();
        yield return null;
       
    }
}
