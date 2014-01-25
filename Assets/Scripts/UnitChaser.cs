using UnityEngine;
using System.Collections;

public class UnitChaser : Unit

{
    // Use this for initialization
    public override void Start()
    {
        base.Start();
    }


    void OnGUI()
    {
        //move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //GUI.TextArea(new Rect(100,100,100,100), string.Format("Move X: {0}\n Move Y: {1}", move.x, move.y));
    }


    // Update is called once per frame
    public override void Update()
    {
        if(GetComponent<NetworkView>().isMine)
        {
            //Movement shiat
            move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            move.Normalize();

            bool strike = Input.GetMouseButtonDown(0);

            if(anim)
            {
                //Swing Weapon Here
                anim.SetBool("Strike", strike);
            }

            base.Update();
        }
    }
}
