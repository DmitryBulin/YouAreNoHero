using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

/// <summary>
/// This class manages player input independantly from any scene
/// </summary>

[CreateAssetMenu(menuName = "Game / Input Reader")]
public class InputReader : ScriptableObject, GameInput.IGameplayActions, GameInput.IMenuActions
{
    // Gameplay
    [SerializeField] private Vector2EventChannelSO MoveEvent = default;
    [SerializeField] private VoidEventChannelSO AttackEvent = default;
    [SerializeField] private VoidEventChannelSO DodgeEvent = default;
    [SerializeField] private VoidEventChannelSO PauseEvent = default;

    // Menu
    [SerializeField] private Vector2EventChannelSO NavigateEvent = default;
    [SerializeField] private VoidEventChannelSO SelectEvent = default;
    [SerializeField] private VoidEventChannelSO CancelEvent = default;

    // Action Map events
    [SerializeField] private BoolEventChannelSO GameplayActionsState = default;
    [SerializeField] private BoolEventChannelSO MenuActionsState = default;

    private GameInput _gameInput;

    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new GameInput();
            _gameInput.Gameplay.SetCallbacks(this);
            _gameInput.Menu.SetCallbacks(this);
        }

        EnableGameplayInput();
    }

    private void OnDisable()
    {
        DisableAllInput();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            AttackEvent?.Invoke();
        }
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DodgeEvent?.Invoke();
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PauseEvent?.Invoke();
        }
    }

    public void OnNavigate(InputAction.CallbackContext context)
    {
        NavigateEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SelectEvent?.Invoke();
        }
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            CancelEvent?.Invoke();
        }
    }
    
    public void EnableGameplayInput()
    {
        _gameInput.Gameplay.Enable();
        _gameInput.Menu.Disable();
        GameplayActionsState?.Invoke(true);
        MenuActionsState?.Invoke(false);
    }

    public void EnableMenuInput()
    {
        _gameInput.Gameplay.Disable();
        _gameInput.Menu.Enable();
        GameplayActionsState?.Invoke(false);
        MenuActionsState?.Invoke(true);
    }

    public void DisableAllInput()
    {
        _gameInput.Gameplay.Disable();
        _gameInput.Menu.Disable();
        GameplayActionsState?.Invoke(false);
        MenuActionsState?.Invoke(false);
    }

}
