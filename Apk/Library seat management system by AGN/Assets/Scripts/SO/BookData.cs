using UnityEngine;

[CreateAssetMenu(fileName = "NewBook", menuName = "Library/Book")]
public class BookDataMain : ScriptableObject
{
    public string bookName;            // Book's name
    public Sprite bookPicture;         // Book cover image
    public string borrowerName;        // Name of the person who borrowed it (empty if available)
    public TextAsset bookPDF;          // PDF file of the book
    public float bookReturnTime;
    public string bookID;       // Unique identifier for the book
   
    public bool isAvailable;    // Availability status

    // Method to check if the book is available
    public bool IsAvailable()
    {
        return string.IsNullOrEmpty(borrowerName);
    }
}
