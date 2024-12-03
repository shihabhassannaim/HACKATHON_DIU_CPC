using UnityEngine;
using TMPro;

public class RandomBookingManager : MonoBehaviour
{
    [Header("Booking Prefab and Container")]
    [SerializeField] private GameObject bookingPrefab;   // The prefab to instantiate
    [SerializeField] private Transform contentPanel;     // Container to hold instantiated bookings

    [Header("Booking Data Settings")]
    [SerializeField] private int numberOfBookings = 10;  // Number of bookings to create

    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomBookings();
    }

    // Method to generate random booking data and instantiate prefabs
    void GenerateRandomBookings()
    {
        // Clear existing bookings
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < numberOfBookings; i++)
        {
            // Generate random seat number, booking start and end time
            int seatNumber = Random.Range(1, 101); // Random seat number between 1 and 100
            string startTime = Random.Range(9, 12) + ":" + Random.Range(0, 60).ToString("D2") + " AM"; // Random start time between 9:00 AM and 12:59 AM
            string endTime = (Random.Range(12, 5) + 12) + ":" + Random.Range(0, 60).ToString("D2") + " PM"; // Random end time after the start time

            // Instantiate a new booking prefab
            GameObject newBooking = Instantiate(bookingPrefab, contentPanel);

            // Set the booking data on the instantiated prefab
            TMP_Text[] texts = newBooking.GetComponentsInChildren<TMP_Text>();
            texts[0].text =  seatNumber.ToString();       // Set seat number
            texts[1].text = startTime + " - " + endTime;  // Set start and end time
        }
    }
}
 