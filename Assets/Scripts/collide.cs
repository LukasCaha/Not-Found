using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collide : MonoBehaviour
{
    /*
     0 rocket
     1 shuriken
     2 laser
     3 bullets
         */
    public enum type { rocket, shuriken, laser, bullets };
    public type prefab = type.rocket;

    public ParticleSystem ps;
    bool exploded = false;
    bool cuttedIn = false;

    private void Start()
    {
        switch (prefab)
        {
            case type.rocket:
                break;
            case type.shuriken:
                break;
            case type.laser:
                RaycastHit2D hit = Physics2D.Raycast(transform.position, this.GetComponent<fly>().direction);

                if (hit.collider != null)
                {
                    LineRenderer lr = this.GetComponent<LineRenderer>();
                    lr.positionCount = 2;
                    lr.SetPosition(0, this.transform.position);
                    lr.SetPosition(1, hit.point);
                    Destroy(this.gameObject, 0.1f);
                    if (hit.collider.GetComponent<TextMesh>())
                    {
                        float grey = hit.collider.GetComponent<TextMesh>().color.r * 0.5f;
                        if (grey < 0.2f)
                        {
                            Destroy(hit.transform.gameObject);
                        }
                        hit.collider.GetComponent<TextMesh>().color = new Color(grey, grey, grey);
                    }
                }
                break;
            case type.bullets:
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (prefab)
        {
            case type.rocket:
                if (exploded)
                {
                    return;
                }
                if (collision.tag == "letter")
                {
                    ps.Play();
                    this.GetComponentInChildren<SpriteRenderer>().enabled = false;
                    Destroy(this.gameObject, 2f);
                    exploded = true;
                    this.GetComponent<fly>().isDead = true;
                    foreach (Rigidbody2D rb in GameObject.Find("Evorsion").GetComponentsInChildren<Rigidbody2D>())
                    {
                        Vector2 dir = rb.transform.position - this.transform.position;
                        float dirMagSq = dir.sqrMagnitude;
                        rb.AddForce(Vector3.Normalize(dir) * 1000 / dirMagSq);
                    }
                }
                break;
            case type.shuriken:
                if (cuttedIn)
                {
                    return;
                }
                if (collision.tag == "letter")
                {
                    cuttedIn = true;
                    this.GetComponent<fly>().isDead = true;
                    this.transform.parent = collision.transform;
                    this.GetComponent<Rigidbody2D>().simulated = false;
                    collision.GetComponent<Rigidbody2D>().AddForceAtPosition(Vector3.Normalize(this.GetComponent<fly>().direction)*1000, this.transform.position);
                }
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
