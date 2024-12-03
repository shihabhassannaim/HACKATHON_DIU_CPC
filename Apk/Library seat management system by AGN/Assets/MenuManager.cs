using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject[] panels;  // Array to hold all UI panels

    // Method to switch panels based on index
    public void ShowPanel(int panelIndex)
    {
        // Disable all panels first
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        // Enable the selected panel
        if (panelIndex >= 0 && panelIndex < panels.Length)
        {
            panels[panelIndex].SetActive(true);
        }
        else
        {
            Debug.LogWarning("Panel index out of range!");
        }
    }
}
