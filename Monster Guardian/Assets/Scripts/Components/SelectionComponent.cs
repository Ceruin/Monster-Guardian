using UnityEngine;

public class SelectionComponent : MonoBehaviour
{
    Color previousColor;

    public bool Selected { get; set; } = false;

    public void Select()
    {
        Selected = true;
        previousColor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void DeSelect()
    {
        Selected = false;
        GetComponent<Renderer>().material.color = previousColor;
    }
}