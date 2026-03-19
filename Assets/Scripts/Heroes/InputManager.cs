using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    [SerializeField] Controls controls = null;
    [SerializeField] InputAction move = null;

    public InputAction Move => move;

    //[SerializeField] MovementComponent moveComponent = null;

    protected override void Awake()
    {
        base.Awake();
        controls = new();
    }

    private void OnEnable()
    {
        move = controls.Character.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }
}