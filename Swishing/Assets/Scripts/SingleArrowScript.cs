using UnityEngine;
using UnityEngine.UI;

public class SingleArrowScript : MonoBehaviour
{
    public Vector2 requiredDirection;

    private Image image;
    [SerializeField] GameObject ArrowImage;

    private void Start()
    {
        image = ArrowImage.GetComponent<Image>();
    }

    public void SetColor(Color color)
    {
        image.color = color;
    }

    public void SetNewRotation()
    {
        int angle = Random.Range(0, 4) * 90;
        transform.localRotation = Quaternion.Euler(0f, 0f, angle);

        switch (angle)
        {
            case 0: requiredDirection = Vector2.up; break;
            case 90: requiredDirection = Vector2.left; break;
            case 180: requiredDirection = Vector2.down; break;
            case 270: requiredDirection = Vector2.right; break;
        }
    }

    public bool CheckSwipe(Vector2 swipeDir)
    {
        return Vector2.Dot(swipeDir, requiredDirection) > 0.7f;
    }
}
