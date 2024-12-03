using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class BookSearch : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_InputField searchInputField;  // Input field for search
    [SerializeField] private Transform resultsContainer;       // Parent for result items
    [SerializeField] private GameObject resultItemPrefab;      // Prefab to display each book result

    [Header("Book Data")]
    [SerializeField] private List<BookDataMain> allBooks;          // List of all books (assign in Inspector)

    private void Start()
    {
        searchInputField.onValueChanged.AddListener(OnSearchInputChanged);
        DisplayResults(allBooks); // Display all books initially
    }

    void OnSearchInputChanged(string searchText)
    {
        ClearResults();

        // If input is empty, show all books
        if (string.IsNullOrEmpty(searchText))
        {
            DisplayResults(allBooks);
            return;
        }

        // Filter books based on search text (case-insensitive)
        List<BookDataMain> filteredBooks = allBooks.Where(book =>
            book.bookName.ToLower().Contains(searchText.ToLower())
        ).ToList();

        DisplayResults(filteredBooks);
    }

    void DisplayResults(List<BookDataMain> books)
    {
        foreach (var book in books)
        {
            GameObject resultItem = Instantiate(resultItemPrefab, resultsContainer);
            resultItem.GetComponentInChildren<TMP_Text>().text = book.bookName;
        }
    }

    void ClearResults()
    {
        foreach (Transform child in resultsContainer)
        {
            Destroy(child.gameObject);
        }
    }
}
