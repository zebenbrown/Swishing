using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private SwipeGameManager swipeManager;

    [SerializeField] private InputActionReference Diff1Start;
    [SerializeField] private InputActionReference Diff2Start;
    [SerializeField] private InputActionReference Diff3Start;

    private void Awake()
    {
        swipeManager = GetComponent<SwipeGameManager>();
    }

    private void OnEnable()
    {
        Diff1Start.action.performed += swipeManager.StartDifOne;
        Diff2Start.action.performed += swipeManager.StartDifTwo;
        Diff3Start.action.performed += swipeManager.StartDifThree;
    }

    private void OnDisable()
    {
        Diff1Start.action.performed -= swipeManager.StartDifOne;
        Diff2Start.action.performed -= swipeManager.StartDifTwo;
        Diff3Start.action.performed -= swipeManager.StartDifThree;
    }
}
