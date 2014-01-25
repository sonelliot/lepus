using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    protected Vector2 move = Vector2.zero;
    protected Transform _transform;
    protected Animator anim;

    // Use this for initialization
    public virtual void Start()
    {
        _transform = GetComponent<Transform>();
        anim = GetComponentInChildren<Animator>();
    }

    [RPC]
    void SetVelocity(float velocity)
    {
        if(anim)
        {
            anim.SetFloat("Velocity", velocity);
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(GetComponent<NetworkView>().isMine)
        {
            Vector3 dPos = new Vector3(move.x * movementSpeed * Time.deltaTime, move.y * movementSpeed * Time.deltaTime, 0);
            _transform.position += dPos;
            if(anim)
            {
                anim.SetFloat("Velocity", dPos.magnitude);
                networkView.RPC("SetVelocity", RPCMode.AllBuffered, dPos.magnitude);
            }
        }
    }

    public Vector2 AimDirection()
    {
        var mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        var playerPosition = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        var aimDir = (mousePosition - playerPosition).normalized;
		
        return aimDir;
    }
}
