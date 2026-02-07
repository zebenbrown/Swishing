using UnityEngine;

public class ArrowTimer : MonoBehaviour
{
    private float timer = 3f;
    private Vector3 startScale;

    private void Start()
    {
        startScale = transform.localScale;
    }

    private void Update()
    {
        if (transform.localScale.x > 0)
        {

            timer -= Time.deltaTime;
            float t = timer / 3f;
            transform.localScale = startScale * t;
        }
        else
        {
            transform.localScale = Vector3.zero;
        }

        if (timer <= 0f)
        {
            FindObjectOfType<SwipeGameManager>().SequenceFailed();
        }
    }
}
