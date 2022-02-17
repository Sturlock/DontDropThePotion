using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    CharacterController characterController;

    private bool groundedPlayer;
    public float playerSpeed = 10f;
    public Vector3 playerVelocity = Vector3.zero;
    private Quaternion _facing;
    public bool interact = false;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerVelocity = characterController.velocity;
        _facing = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        if (!characterController.isGrounded)
        {
            playerVelocity.y = -9.81f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Vertical"), playerVelocity.y, -Input.GetAxis("Horizontal"));
        characterController.Move(move * Time.deltaTime * playerSpeed);

        if (characterController.velocity != Vector3.zero)
        {
            Vector3 moveRot = new Vector3(move.x, 0, move.z);
            var rotation = Quaternion.LookRotation(moveRot);
            rotation *= _facing;
            transform.rotation = rotation;
        }
        if (Input.GetKey(KeyCode.E))
        {
            interact = true;
        }
        else interact = false;
    }
}
