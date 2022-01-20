using UnityEngine;
using UnityEngine.EventSystems;

public class TabPlatform : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isDown;
    public bool start;
   

    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
        start = false;
    }

    

    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
        start = true;
    }
}
