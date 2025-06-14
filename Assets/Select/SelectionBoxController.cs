
using UnityEngine;

public class SelectionBoxController : MonoBehaviour
{
    SelectableRegistry selectObject;
    public GUISkin GUISkin; // GUI skin for the selection box.
    private Rect screenSpaceRect; // Rectangle representing the selection box.
    private bool drawFrame; // Flag to indicate if the selection box should be drawn.

    private Vector2 startPoint; // Starting point of the selection box.
    private Vector2 endPoint; // Ending point of the selection box.
    private int sortingLayer = 99; // Sorting layer for the GUI.
    private float minDragDistance = 10f; // Minimum distance to start drawing the frame.
    private bool isPointerEnterUI = false; // to check if the mouse cursor is on the UI

    private void Awake()
    {
        selectObject = GetComponent<SelectableRegistry>();
    }
    
    // OnGUI is called for rendering and handling GUI events.
    private void OnGUI()
    {
        GUI.skin = GUISkin; // Set the GUI skin.
        GUI.depth = sortingLayer; // Set the sorting layer.
        HandleSelectionStart(); // Handle the start of the selection.
        HandleSelectionUpdate(); // Handle the ongoing selection.
        HandleSelectionEnd(); // Handle the end of the selection.
    }
    // Method to start the selection process.
    private void HandleSelectionStart()
    {
        if (isPointerEnterUI) return; //checking that the mouse cursor does not fall into ui elements
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Input.mousePosition; // Record the starting point of the selection.
            drawFrame = true; // Enable the drawing of the selection frame. 
        }
    }

    // Method to handle the selection process while the mouse button is pressed.
    private void HandleSelectionUpdate()
    {
        if (Input.GetMouseButton(0) && drawFrame)
        {
            endPoint = Input.mousePosition; // Update the ending point of the selection.
            if (Vector2.Distance(startPoint, endPoint) > minDragDistance) //check minimum frame size
            {
                // Calculate the inverted rectangle for the selection box.
                screenSpaceRect = GetScreenRect(startPoint, endPoint);
                DrawBox(screenSpaceRect);
            }
        }
    }

    // Method to finish the selection process.
    private void HandleSelectionEnd()
    {
        if (Input.GetMouseButtonUp(0))
        {
            endPoint = Input.mousePosition; // Finalize the ending point of the selection.
            drawFrame = false; // Disable the drawing of the selection frame.   
            SelectItemsInRect(screenSpaceRect); // Select persons within the selection box.  
        }
    }
    // Method to calculate the inverted rectangle for negative values.
    private Rect GetScreenRect(Vector2 startPoint, Vector2 endPoint)
    {

        float posX = Mathf.Min(startPoint.x, endPoint.x);// This is the left edge of the rectangle. 
        float posY = Mathf.Min(startPoint.y, endPoint.y);// subtract the top edge value from the screen height. 
        float widthX = Mathf.Abs(endPoint.x - startPoint.x); // This is the difference between the maximum and minimum x-coordinates. 
        float heightY = Mathf.Abs(endPoint.y - startPoint.y); // This is the difference between the maximum and minimum y-coordinates.

        // Create and return a new Rect with the calculated x, y, width, and height.
        return new Rect(posX, posY, widthX, heightY);
    }

    private void DrawBox(Rect screenRect)
    {
        float x = screenRect.x;
        float y = Screen.height - screenRect.y - screenRect.height;
        float height = screenRect.height;
        float width = screenRect.width;

        Rect newBox = new Rect(x, y, width, height);
        GUI.Box(newBox, ""); // Draw the selection box. 
    }


    // Method to select persons within the selection box.
    private void SelectItemsInRect(Rect screenRect)
    {
        foreach (var item in selectObject.itemFromScreen)// Iterate over each person in the character system's squad.
        {
            Vector2 posScreen = RectTransformUtility.WorldToScreenPoint(null, item.rectTransform.position); // Get the screen position of the person.
            if (screenRect.Contains(posScreen)) // Check if the person's screen position is within the selection box.
            {
                // Enable components for persons inside the selection box.
                Debug.Log("select " + item.name);
            } 
        }
    }



}
