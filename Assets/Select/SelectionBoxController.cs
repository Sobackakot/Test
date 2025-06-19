
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
    
    private void OnGUI()
    {
        GUI.skin = GUISkin; 
        GUI.depth = sortingLayer; 
        SelectionStart();
        SelectionStay();
        if (Event.current.type == EventType.Repaint)
            SelectionEnd();
    }
   
    private void SelectionStart()
    {
        if (isPointerEnterUI) return;
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Input.mousePosition; 
            drawFrame = true; 
        }
    }
    private void SelectionStay()
    {
        if (Input.GetMouseButton(0) && drawFrame)
        {
            endPoint = Input.mousePosition; 
            if (Vector2.Distance(startPoint, endPoint) > minDragDistance) 
            {
                screenSpaceRect = GetRectFrame(startPoint, endPoint);
                DrawFrame(screenSpaceRect);
            }
        }
    }
     
    private void SelectionEnd()
    {
        if (Input.GetMouseButtonUp(0))
        {
            endPoint = Input.mousePosition; 
            drawFrame = false; 
            SelectionFrameFromScreen(screenSpaceRect); 
        }
    }
    //Вычисляет корректный прямоугольник
    private Rect GetRectFrame(Vector2 startPoint, Vector2 endPoint)
    { 
        float posX = Mathf.Min(startPoint.x, endPoint.x);
        float posY = Mathf.Min(startPoint.y, endPoint.y);
        float widthX = Mathf.Abs(endPoint.x - startPoint.x);  
        float heightY = Mathf.Abs(endPoint.y - startPoint.y); 

        return new Rect(posX, posY, widthX, heightY);
    }

    //Отрисовывает GUI.Box — прямоугольник рамки выбора.
    private void DrawFrame(Rect screenRect)
    {
        //Unity GUI использует экранные координаты снизу вверх, а в Screen Space Y идёт вниз
        //Поэтому y координата корректируется: Screen.height - y - height.

        float x = screenRect.x;
        float y = Screen.height - screenRect.y - screenRect.height;
        float width = screenRect.width;
        float height = screenRect.height;
         
        Rect newBox = new Rect(x, y, width, height);
        GUI.Box(newBox, ""); 
    }

    private void SelectionFrameFromScreen(Rect screen)
    {
        foreach (var item in selectObject.itemFromScreen)
        { 
            Rect itemRect = GetRectItem(item);
            //проверяет, пересекаются ли прямоугольники
            if (screen.Overlaps(itemRect, true))
            {
                Debug.Log("select " + item.name);
            }
        }
    }
    
    //Вычисляет прямоугольник (DraggableItem item) - UI-объекта на экране
    private Rect GetRectItem(DraggableItem item)
    {
        Vector3[] positions = new Vector3[4];
        item.rectTransform.GetWorldCorners(positions);//возвращает 4 угла RectTransform в мировых координатах.

        //мы получаем координаты в экранном пространстве.
        Vector2 bottom_Left = RectTransformUtility.WorldToScreenPoint(null, positions[0]);
        Vector2 top_Right = RectTransformUtility.WorldToScreenPoint(null, positions[2]);
         
        float x = Mathf.Min(bottom_Left.x, top_Right.x);
        float y = Mathf.Min(bottom_Left.y, top_Right.y);
        float width = Mathf.Abs(top_Right.y - bottom_Left.y);
        float height = Mathf.Abs(top_Right.x - bottom_Left.x);
        
        return new Rect(x, y, width,height);
    }
}
