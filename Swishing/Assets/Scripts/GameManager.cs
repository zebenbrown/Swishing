using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private SwipeGameManager swipeManager;

    [SerializeField] private InputActionReference swipeMinigameStart;

    private void Start()
    {
        swipeManager = GetComponent<SwipeGameManager>();
    }

    private void OnEnable()
    {
        swipeMinigameStart.action.performed += InitiateSwipeGame;
    }

    public void InitiateSwipeGame(InputAction.CallbackContext context)
    {
        swipeManager.StartSwipeGame();
    }
}
