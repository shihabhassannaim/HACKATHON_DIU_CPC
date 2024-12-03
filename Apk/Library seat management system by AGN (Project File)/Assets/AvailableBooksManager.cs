
using UnityEngine;
using TMPro;
using System.Linq;

public class AvailableBooksManager : MonoBehaviour
{
    [Header("Book Data List")]
    public BookDataMain[] books;  // Array of BookData Scriptable Objects (assign in Inspector)

    [Header("UI Elements")]
    [SerializeField] private GameObject bookPrefab;       // Assign your BookPrefab in the Inspector
    [SerializeField] private Transform contentPanel;      // Container for displaying books
    [SerializeField] private TMP_InputField searchInput;  // Reference to the TextMeshPro InputField for searching

    void Start()
    {
        DisplayAvailableBooks();  // Display all books initially
        searchInput.onValueChanged.AddListener(OnSearchChanged);  // Attach search function to input changes
    }

    void DisplayAvailableBooks(string filter = "")
    {
        // Clear any existing entries in the content panel
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        // Filter books based on the search query and availability
        var filteredBooks = books
            .Where(book => book.isAvailable && (string.IsNullOrEmpty(filter) || book.bookName.ToLower().Contains(filter.ToLower())))
            .ToList();

        // Instantiate a new prefab for each matching book
        foreach (BookDataMain book in filteredBooks)
        {
            GameObject bookItem = Instantiate(bookPrefab, contentPanel);

            // Set the text to display the book name
            TMP_Text bookText = bookItem.GetComponentInChildren<TMP_Text>();
            if (bookText != null)
            {
                bookText.text = book.bookName;
            }

            // Optional: Set the book cover image if available
            UnityEngine.UI.Image bookImage = bookItem.GetComponentInChildren<UnityEngine.UI.Image>();
            if (bookImage != null && book.bookPicture != null)
            {
                bookImage.sprite = book.bookPicture;
            }
        }
    }

    void OnSearchChanged(string searchQuery)
    {
        DisplayAvailableBooks(searchQuery);  // Update displayed books based on search input
    }
}
