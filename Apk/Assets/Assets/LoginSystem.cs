using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Required for TextMesh Pro
using LootLocker.Requests;
using UnityEngine.Events;

public class LootLockerGuestLoginUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInput;  // Reference to the TextMeshPro InputField
    [SerializeField] private Button loginButton;  // Reference to the Button
    [SerializeField] private TMP_Text statusText;  // Optional: Display login status    public Unityeve
    public UnityEvent OnLoginSucrssfully;
    void Start()
    {
        // Attach the login function to the button click event
        loginButton.onClick.AddListener(GuestLogin);
    }

    void GuestLogin()
    {
        string playerName = playerNameInput.text;

        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Guest login successful!");
                statusText.text = $"Welcome, {playerName}!";
                // You can store player data or load another scene here
                OnLoginSucrssfully?.Invoke();
            }
            else
            {
                Debug.LogError("Guest login failed: " + response.errorData.message);
                statusText.text = "Login failed. Please try again.";
            }
        });
    }
}
