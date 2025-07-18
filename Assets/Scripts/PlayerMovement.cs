using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private PlayerInputHandler playerInputHandler;

    [Tooltip("How fast the player rotates toward movement direction.")]
    [SerializeField] private float rotationSpeed;

    [Tooltip("Movement speed of the player.")]
    [SerializeField] private float speed;

    [Tooltip("Reference to the Animator component.")]
    [SerializeField] private Animator anim;

    [Tooltip("Handles gravity and physics behavior.")]
    [SerializeField] private CharacterPhysics physics;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerInputHandler = GetComponent<PlayerInputHandler>();
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 input = playerInputHandler.MoveInput;
        Vector3 move = new Vector3(input.x, 0, input.y);

        if (move.magnitude > 0.1f)
        {
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        }
        anim.SetBool("isRunning", move.magnitude > 0.1f);


        Vector3 applyPhysics = physics.ApplyGravity(move);


        characterController.Move(applyPhysics * speed * Time.deltaTime);
    }


}
