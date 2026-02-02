using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeGameManager : MonoBehaviour
{
    private GameManager gameManager;

    private bool minigameActive = false;

    public float minSwipeDistance = 100f;
    public float maxSwipeTime = 0.5f;

    private Vector2 startPos;
    private float mouseDistance;
    private float startTime;
    private bool tracking;
    private bool mouseDown = false;

    [SerializeField] private InputActionReference swipeStart;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    private void OnEnable()
    {
        swipeStart.action.performed += TrackMouse;
    }

    private void TrackMouse(InputAction.CallbackContext context)
    {
        if (minigameActive)
        {
            startPos = Input.mousePosition;
            startTime = Time.time;
            tracking = true;
            mouseDown = true;
        }
    }

    private void DEBUGCheckMouseDirection()
    {
        Debug.Log(Vector2.Distance(startPos, Input.mousePosition));
    }

    private void CheckSwipeDirection(Vector2 currMousePos)
    {
        if (currMousePos.x < (startPos.x - 100))
        {
            if (currMousePos.y < (startPos.y - 100))
            {

            }
            else
            {

            }
        }
    }

    public void StartSwipeGame()
    {
        minigameActive = true;

        Debug.Log("Minigame Started");
    }
}
