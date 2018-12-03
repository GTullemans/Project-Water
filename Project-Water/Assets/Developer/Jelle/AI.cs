using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

public class AI : MonoBehaviour {

    public bool switchState = false;
    public float timer;
    public int seconds = 0;

    public Rigidbody RB;
    public StateMachine<AI> stateMachine{ get; set; }

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        stateMachine = new StateMachine<AI>(this);
        stateMachine.ChangeState(FirstState.Instance);
        timer = Time.time;
    }

    private void Update()
    {
        if(Time.time > timer + 1)
        {
            timer = Time.time;
            seconds++;
            print(seconds);
        }

        if(seconds == 5)
        {
            seconds = 0;
            switchState = !switchState;
        }
        stateMachine.Update();
    }
}
