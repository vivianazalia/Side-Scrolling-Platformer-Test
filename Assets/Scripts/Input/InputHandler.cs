using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="Input Handler", menuName ="Input/Input Handler")]
public class InputHandler : ScriptableObject, GameInput.IPlayerActions, GameInput.IUIGameplayActions, GameInput.IMainMenuActions
{
    #region Events
    public event UnityAction<float> MoveEvent = delegate { };
    public event UnityAction JumpEvent = delegate { };
    public event UnityAction AttackEvent = delegate { };
    public event UnityAction PauseGame = delegate { };
    public event UnityAction StartGameEvent = delegate { };
    public event UnityAction QuitGameEvent = delegate { };
    #endregion

    #region Variables
    private GameInput _gameInput;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        if(_gameInput == null)
        {
            _gameInput = new GameInput();
            _gameInput.Player.SetCallbacks(this);
            _gameInput.UIGameplay.SetCallbacks(this);
            _gameInput.MainMenu.SetCallbacks(this);
        }

        GameplayInputEnable();
    }

    private void OnDisable()
    {
        DisableAllInput();
    }
    #endregion

    #region Methods
    public void MainMenuInputEnable()
    {
        _gameInput.Player.Disable();
        _gameInput.UIGameplay.Disable();

        _gameInput.MainMenu.Enable();
    }

    public void GameplayInputEnable()
    {
        _gameInput.Player.Enable();
        _gameInput.UIGameplay.Enable();

        _gameInput.MainMenu.Disable();
    }

    public void DisableAllInput()
    {
        _gameInput.Player.Disable();
        _gameInput.UIGameplay.Disable();

        _gameInput.MainMenu.Disable();
    }
    #endregion

    #region IPlayerActions
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
            JumpEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<float>());
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            AttackEvent?.Invoke();
    }
    #endregion

    #region IUIGameplayActions
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
            PauseGame?.Invoke();
    }
    #endregion

    #region IMainMenuActions
    public void OnStartGame(InputAction.CallbackContext context)
    {
        if (context.performed)
            StartGameEvent?.Invoke();
    }

    public void OnQuit(InputAction.CallbackContext context)
    {
        if (context.performed)
            QuitGameEvent?.Invoke();
    }
    #endregion
}
