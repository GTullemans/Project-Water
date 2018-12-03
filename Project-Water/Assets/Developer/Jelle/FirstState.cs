using UnityEngine;
using States;

public class FirstState : State<AI>
{
    private static FirstState _instance;

    private FirstState()
    {
        if(_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static FirstState Instance
    {
        get
        {
            if(_instance == null)
            {
                new FirstState();
            }

            return _instance;
        }
    }
    public override void EnterState(AI _owner)
    {

        Debug.Log("faggot");
        Vector3 pos = _owner.transform.position;
        _owner.transform.position = new Vector3(pos.x + Random.Range(0, 5) * Time.deltaTime, 0.5f, pos.z + Random.Range(0, 5) * Time.deltaTime); ;
    }

    public override void ExitState(AI _owner)
    {
        Debug.Log("eerste state verlaten");
    }

    public override void UpdateState(AI _owner)
    {
        if(_owner.switchState)
        {
            _owner.stateMachine.ChangeState(SecondState.Instance);
        }
    }
}
