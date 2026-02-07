using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeGameManager : MonoBehaviour
{
    [SerializeField] private PanelGroupScript panelGroup;
    [SerializeField] private SwipeInput swipeInput;

    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;

    private int difficulty; // 1–3
    private int currentSequence;
    private const int TOTAL_SEQUENCES = 4;

    public void StartDifOne(InputAction.CallbackContext context)
    {
        StartSwipeGame(1);
    }

    public void StartDifTwo(InputAction.CallbackContext context)
    {
        StartSwipeGame(2);
    }

    public void StartDifThree(InputAction.CallbackContext context)
    {
        StartSwipeGame(3);
    }

    public void StartSwipeGame(int diff = 1)
    {
        if (WinPanel != null)
        {
            WinPanel.SetActive(false);
        }
        if (LosePanel != null)
        {
            LosePanel.SetActive(false);
        }
        difficulty = diff;
        currentSequence = 0;
        Debug.Log("Swipe Minigame Started | Difficulty: " + difficulty);
        StartNextSequence();
    }

    private void StartNextSequence()
    {
        if (currentSequence >= TOTAL_SEQUENCES)
        {
            if (WinPanel != null)
            {
                WinPanel.SetActive(true);
            }
            Debug.Log("MINIGAME WON");
            return;
        }

        panelGroup.ClearPanels();
        panelGroup.SpawnArrows(difficulty);
        swipeInput.EnableInput(panelGroup.GetArrows());

        currentSequence++;
    }

    public void SequenceFailed()
    {
        if (LosePanel != null)
        {
            LosePanel.SetActive(true);
        }
        Debug.Log("MINIGAME FAILED");
    }

    public void SequenceSucceeded()
    {
        StartNextSequence();
    }
}
