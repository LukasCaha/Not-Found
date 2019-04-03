using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;

    float timeOfShoot = 0;
    public float cooldown = 1;
    public Transform cannonBarel;

    private void Start()
    {
        this.transform.LookAt(Vector2.zero);
    }

    private void Update()
    {
        //look at
        Vector2 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.LookAt(mousePositionInWorld);
        //shoot
        if (Input.GetMouseButtonDown(0) && timeOfShoot < Time.time)
        {
            Shoot();   
        }   
    }

    void Shoot()
    {
        timeOfShoot = Time.time + cooldown;
        GameObject b = Instantiate(bullet, cannonBarel.position, Quaternion.identity)as GameObject;
        Vector3 dir = cannonBarel.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        b.GetComponent<fly>().direction = -dir;
    }
}
