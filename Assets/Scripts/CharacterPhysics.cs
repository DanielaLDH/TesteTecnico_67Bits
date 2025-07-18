using UnityEngine;

public class CharacterPhysics : MonoBehaviour
{
    [Tooltip("Gravity value applied to the character.")]
    [SerializeField] private float gravity;

    [Tooltip("Reference to the CharacterController component.")]
    [SerializeField] private CharacterController characterController;

    private float verticalVelocity;

    public Vector3 ApplyGravity(Vector3 moveDirection)
    {
        if (characterController.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = 0f;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        moveDirection.y = verticalVelocity;
        return moveDirection;
    }
}
