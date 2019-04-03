using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 1;

    private void Start()
    {
        this.transform.Rotate(direction);
    }

    void Update()
    {
        direction.z = 0;
        this.transform.Translate(Vector3.Normalize(direction)*Time.deltaTime*speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
