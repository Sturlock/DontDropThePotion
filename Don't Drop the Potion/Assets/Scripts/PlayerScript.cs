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
        if (characterController.isGrounded)
        {
            Debug.Log("Grounded");
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move * Time.deltaTime * playerSpeed);

        var rotation = Quaternion.LookRotation(move.normalized);
        rotation *= _facing;
        transform.rotation = rotation;
    }
}
