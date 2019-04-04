using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour
{
    /*
     0 rocket
     1 shuriken
     2 laser
     3 bullets
         */
    public enum type {rocket,shuriken,laser,bullets};
    public type prefab = type.rocket;

    public Vector3 direction;
    public float speed = 1;
    public bool isDead = false;

    private void Start()
    {
        //this.transform.LookAt(direction);
    }

    void Update()
    {
        switch (prefab)
        {
            case type.rocket:
                if (isDead)
                {
                    return;
                }
                direction.z = 0;
                this.transform.Translate(Vector3.Normalize(direction) * Time.deltaTime * speed);
                break;
            case type.shuriken:
                if (isDead)
                {
                    return;
                }
                direction.z = 0;
                this.transform.Translate(Vector3.Normalize(direction) * Time.deltaTime * speed);
                this.transform.GetComponentInChildren<SpriteRenderer>().gameObject.transform.Rotate(Vector3.forward*500*Time.deltaTime);
                break;
            case type.laser:
                break;
            case type.bullets:
                break;
            default:
                break;
        }
        
    }
}
