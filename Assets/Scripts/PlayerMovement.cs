using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 5.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private float horizontal, vertical;
    private bool hasJumped;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(horizontal, 0, vertical);
        controller.Move(move.normalized * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (hasJumped && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            hasJumped = false;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        SetPlayerPosition();
    }

    private void SetPlayerPosition()
    {
        Player.Instance.currentPosition = transform.position;
    }

    public void MoveInput(Vector2 newMoveDir)
    {
        horizontal = newMoveDir.x;
        vertical = newMoveDir.y;
    }

    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }

    public void JumpInput(bool newJumpState)
    {
        hasJumped = newJumpState;
    }

    public void OnJump(InputValue value)
    {
        JumpInput(value.isPressed);
    }

    private void OnApplicationQuit()
    {
        SetPlayerPosition();
    }
}
