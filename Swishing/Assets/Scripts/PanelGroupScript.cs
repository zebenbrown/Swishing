using System.Collections.Generic;
using UnityEngine;

public class PanelGroupScript : MonoBehaviour
{
    [SerializeField] private GameObject ArrowPanel_PREFAB;

    private List<SingleArrowScript> arrows = new List<SingleArrowScript>();
    private int numPanels;

    public void SpawnArrows(int difficultyInt)
    {
        ChooseDifficulty(difficultyInt);

        for (int i = 0; i < numPanels; i++)
        {
            GameObject panel = Instantiate(ArrowPanel_PREFAB, transform);
            panel.AddComponent<ArrowTimer>();

            SingleArrowScript arrow = panel.GetComponent<SingleArrowScript>();
            arrow.SetNewRotation();
            arrows.Add(arrow);
        }
    }

    public void ClearPanels()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);

        arrows.Clear();
    }

    public List<SingleArrowScript> GetArrows()
    {
        return arrows;
    }

    private void ChooseDifficulty(int difficultyInt)
    {
        numPanels = difficultyInt + 1;
    }
}
