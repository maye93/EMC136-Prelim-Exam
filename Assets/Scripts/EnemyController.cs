using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;  // Constant speed
    public float rotationSpeed = 3f;
    [SerializeField] float detectionDistance;  // Raycast distance to detect the player

    public GameObject playerObject;
    private CharacterController characterController;

    private void Start()
    {
        // Check if the CharacterController component is attached, and add it if not
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            characterController = gameObject.AddComponent<CharacterController>();
        }
    }

    private void FixedUpdate()
    {
        RotateTowardsPlayer();
        MoveForward();
    }

    private void RotateTowardsPlayer()
    {
        Vector3 targetDirection = playerObject.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
    }

    public void MoveForward()
    {
        characterController.SimpleMove(transform.forward * speed);
    }

    public void StartMovement()
    {
        speed = 5f;
    }

    public void StopMovement()
    {
        speed = 0f;
    }
}