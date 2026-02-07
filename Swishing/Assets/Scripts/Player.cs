using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject hook;
    public GameObject gameManager;

    float horizontalMovement;
    float verticalMovement;

    bool isInWater;

    [SerializeField] Rigidbody hookRb;
    [SerializeField] float castSpeed;
    [SerializeField] float hookMoveSpeed;
    [SerializeField] Collider hookCollider;
    
    public void FixedUpdate()
    {
        hookRb.linearVelocity = new Vector2(horizontalMovement, verticalMovement);
    }

    public void Cast(InputAction.CallbackContext context)
    {
        Debug.Log("Cast");
        hookRb.AddForce(transform.up * castSpeed * -1);
    }

    public void Move(InputAction.CallbackContext context)
    {
        //Debug.Log("Move");
        horizontalMovement = (context.ReadValue<Vector2>().x) * hookMoveSpeed;
        verticalMovement = (context.ReadValue<Vector2>().y) * hookMoveSpeed;
    }
    /*
    private void OnTriggerEnter(Collider collision)
    {
        if (hookCollider.gameObject.CompareTag("Water"))
        {
            Debug.Log("Splash!");
        }
    }
    */


}
