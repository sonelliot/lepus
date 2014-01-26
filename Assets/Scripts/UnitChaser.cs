using UnityEngine;
using System.Collections;

public class UnitChaser : Unit
{
    public GameObject gameController;
    protected float _stunTime = 3.0f;
    private int Strike = 0;
    private bool isNotFucked = true;

    // Use this for initialization
    public override void Start()
    {
        gameController = GameObject.Find("GameController");
        base.Start();
    }

    [RPC] 
    void DisableEnemy()
    {
        isNotFucked = false;
    }
	
    [RPC]
    void EnableEnemy()
    {
        isNotFucked = true;
    }

    void OnGUI()
    {
        //move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //GUI.TextArea(new Rect(100,100,100,100), string.Format("Move X: {0}\n Move Y: {1}", move.x, move.y));
    }
    
    [RPC]
    void SetStrike(int strike)
    {
        if(anim)
        {
            anim.SetBool("Strike", strike != 0);
        }
    }

    private void UpdateStunnedStuff()
    {
        _stunTime -= Time.deltaTime;
		
        if(_stunTime < 0.0f)
        {
            isNotFucked = true;
            _stunTime = 5.0f;
        }
    }
    // Update is called once per frame
    public override void Update()
    {
        if(GetComponent<NetworkView>().isMine &&
            gameController.GetComponent<GameController>().InputEnabled && isNotFucked)
        {
            //Movement shiat
            move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            move.Normalize();

            if(Strike != 0)
            {
                --Strike;
            }
            else
            {
                Strike = Input.GetMouseButtonDown(0) ? 6 : 0;
            }

            if(anim && Strike >= 0)
            {
                //Swing Weapon Here
                anim.SetBool("Strike", Strike != 0);
                networkView.RPC("SetStrike", RPCMode.AllBuffered, Strike);
            }

            base.Update();
        }

        if(!isNotFucked)
        {
            UpdateStunnedStuff();
        }
    }
}
