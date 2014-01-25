using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class KnifeyScript : MonoBehaviour
{
    public Unit player; 
    // Use this for initialization
    void Start ()
    {
        rigidbody2D.AddForce (new Vector2 (50.0f, 50.0f));
        transform.Rotate (new Vector3 (180, 0, 0));
        //rigidbody2D.AddForce(player.AimDirection*5);
    }

    void OnCollisionEnter2D (Collision2D coll)
    {

    }

    // Update is called once per frame
    void Update ()
    {

    }
}
