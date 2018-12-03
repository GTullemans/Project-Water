using UnityEngine;
using States;

public class SecondState : State<AI>
{
    private static SecondState _instance;

    private SecondState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static SecondState Instance
    {
        get
        {
            if (_instance == null)
            {
                new SecondState();
            }

            return _instance;
        }
    }
    public override void EnterState(AI _owner)
    {
        Debug.Log("tweede state starten");
    }

    public override void ExitState(AI _owner)
    {
        Debug.Log("tweede state verlaten");
    }

    public override void UpdateState(AI _owner)
    {
        if (!_owner.switchState)
        {
            _owner.stateMachine.ChangeState(FirstState.Instance);
        }
    }
}
