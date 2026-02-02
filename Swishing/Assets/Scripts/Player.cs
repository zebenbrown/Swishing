using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject hook;

    [SerializeField] Rigidbody hookRb;
    [SerializeField] float castSpeed = 5f;
    
    public void Cast(InputAction.CallbackContext context)
    {
        Debug.Log("Cast");
        hookRb.AddForce(transform.up * castSpeed * -1);
    }

    public void Move(InputAction.CallbackContext context)
    {
        Debug.Log("Move");
    }
}
