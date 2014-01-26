using UnityEngine;
using System.Collections;

public class UnitChaser : Unit
{
	protected float _stunTime = 3.0f;
    private bool prevStrike;
	private bool isNotFucked = true;

    // Use this for initialization
    public override void Start()
    {
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
        if(GetComponent<NetworkView>().isMine && isNotFucked)
        {
            //Movement shiat
            move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            move.Normalize();

            bool strike = Input.GetMouseButtonDown(0);

            if(anim && (prevStrike != strike))
            {
                //Swing Weapon Here
                anim.SetBool("Strike", strike);
                networkView.RPC("SetStrike", RPCMode.AllBuffered, strike ? 2 : 0);
                prevStrike = strike;
            }

            base.Update();
        }

		if(!isNotFucked)
		{
			UpdateStunnedStuff();
		}
    }
}
