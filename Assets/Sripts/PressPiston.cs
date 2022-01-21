using UnityEngine;
using UnityEngine.EventSystems;

public class PressPiston : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool click = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        click = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        click = false;
    }
}
