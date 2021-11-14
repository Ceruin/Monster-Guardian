using UnityEngine;

/// <summary>
/// Makes object draggable in UI
/// </summary>
public class Draggable : MonoBehaviour
{
    private Vector3 _offset;
    private float _zcord;

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition; // x, y
        mousePoint.z = _zcord; // z
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDown()
    {
        _zcord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        _offset = gameObject.transform.position - GetMouseWorldPos(); // store offset = gameobj world pos - mouse world pos
    }
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + _offset;
    }
}