using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameInputManager : MonoBehaviour
{
    private static GameInputManager instance;
    public static GameInputManager Instance => instance;
    private GameInputActions gameInput;

    [SerializeField] private MouseLook mouseLook;

    public Vector2 mouseInput;

    private void Awake()
    {
        SingletonlInitialization();
        GameInputInitialization();
    }

    private void GameInputInitialization()
    {
        gameInput = new GameInputActions();
        gameInput.Enable();

        gameInput.Player.Jump.performed += _ => PlayerManager.Instance.GetPlayerMovement().JumpPerformed();
        gameInput.Player.Movement.performed += context => PlayerManager.Instance.GetPlayerMovement().MovementPerformed(context);
        gameInput.Player.Movement.started += _ => PlayerManager.Instance.GetPlayerMovement().MovementStarted();
        gameInput.Player.Movement.canceled += _ => PlayerManager.Instance.GetPlayerMovement().MovementCanceled();


        gameInput.Player.MouseX.performed += context => mouseInput.x = context.ReadValue<float>();
        gameInput.Player.MouseY.performed += context => mouseInput.y = context.ReadValue<float>();
        gameInput.Player.MouseY.started += _ => MouseLook.Instance.MouseStartY();
        gameInput.Player.MouseY.canceled += _ => MouseLook.Instance.MouseStopY();
        gameInput.Player.MouseX.started += _ => MouseLook.Instance.MouseStartX();
        gameInput.Player.MouseX.canceled += _ => MouseLook.Instance.MouseStopX();



       // gameInput.Player.Interact.performed += _ => PlayerManager.Instance.GetPlayerMovement().InteractionPerformed();
        gameInput.Player.Interact.started += _ => PlayerManager.Instance.GetPlayerMovement().InteractionStarted();
        gameInput.Player.Interact.canceled += _ => PlayerManager.Instance.GetPlayerMovement().InteractionCanceled();
        gameInput.Player.SelectWeaponScroll.performed += context => WeaponManager.Instance.SelectWeapon(context);

        gameInput.Player.Fire.performed += _ => Weapons.Instance.Shoot();

    }

    private void SingletonlInitialization()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        mouseLook.ReceiveInput(mouseInput);
    }
}