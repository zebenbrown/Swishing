using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeInput : MonoBehaviour
{
    private Vector2 startPos;
    private bool swiping;

    [SerializeField] private InputActionReference SwipePress;

    private Queue<SingleArrowScript> arrowQueue;

    [SerializeField] private Color startColor;
    [SerializeField] private Color ActiveColor;

    public void EnableInput(List<SingleArrowScript> arrows)
    {
        arrowQueue = new Queue<SingleArrowScript>(arrows);
        swiping = false;
    }

    private void OnEnable()
    {
        SwipePress.action.Enable();
    }

    private void Update()
    {
        if (arrowQueue == null || arrowQueue.Count == 0) return;

        if (SwipePress.action.WasPressedThisFrame())
        {
            //Debug.Log("Swiper yes Swiping");

            startPos = Mouse.current.position.ReadValue();
            swiping = true;
            //arrowQueue.First<SingleArrowScript>().SetColor(ActiveColor);
        }

        if (SwipePress.action.WasReleasedThisFrame() && swiping)
        {
            Vector2 endPos = Mouse.current.position.ReadValue();
            Vector2 delta = endPos - startPos;
            swiping = false;
            //Debug.Log("Swiper no Swiping");

            Vector2 dir = delta.normalized;
            SingleArrowScript currentArrow = arrowQueue.Dequeue();

            if (!currentArrow.CheckSwipe(dir))
            {
                //FindObjectOfType<SwipeGameManager>().SequenceFailed();
            }
            else if (arrowQueue.Count == 0)
            {
                FindObjectOfType<SwipeGameManager>().SequenceSucceeded();
            }

            //arrowQueue.First<SingleArrowScript>().SetColor(ActiveColor);
        }
    }

}
