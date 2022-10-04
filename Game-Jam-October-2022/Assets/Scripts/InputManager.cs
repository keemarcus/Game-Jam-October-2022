using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float moveAmount;
    public float mouseX;
    public float mouseY;

    public bool attackInput;
    public bool interactInput;

    PlayerControls inputActions;
    PlayerManager playerManager;

    Vector2 movementInput;
    Vector2 scrollWheel;

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    public void OnEnable()
    {
        if (inputActions == null)
        {
            // set up new Player Controls instance
            inputActions = new PlayerControls();
            inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
            inputActions.PlayerActions.Attack.performed += i => attackInput = true;
            inputActions.PlayerActions.Interact.performed += i => interactInput = true;
            inputActions.SpellCasting.ChangeSpell.performed += inputActions => scrollWheel = inputActions.ReadValue<Vector2>().normalized;
        }

        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void TickInput(float delta)
    {
        HanldeMoveInput(delta);
        HandleAttackInput(delta);
        HandleInteractInput(delta);
        HandleScrollInput(delta);
    }

    private void HanldeMoveInput(float delta)
    {
        // update moveAmount based on player input
        horizontal = movementInput.x;
        vertical = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
    }

    private void HandleAttackInput(float delta)
    {
        if (attackInput)
        {
            playerManager.HandleAttack();
        }
    }

    private void HandleInteractInput(float delta)
    {
        if (interactInput)
        {
            playerManager.HandleInteract();
        }
    }

    private void HandleScrollInput(float delta)
    {
        if(scrollWheel.y != 0f)
        {
            playerManager.ChangeActiveSpell(scrollWheel.y);
        }
    }
}
