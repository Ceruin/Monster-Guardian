using System.Collections.Generic;
using UnityEngine;

public class SelectedAlliesModel : MonoBehaviour
{
    public Dictionary<int, GameObject> SelectedTable = new Dictionary<int, GameObject>();

    public void AddSelection(GameObject go)
    {
        int id = go.GetInstanceID();

        if (!(SelectedTable.ContainsKey(id)))
        {
            SelectedTable.Add(id, go);
            go.GetComponent<SelectionComponent>().Select();
            Debug.Log("Added " + id + " to selected dict");
        }
    }

    public void DeselectAll()
    {
        foreach (KeyValuePair<int, GameObject> pair in SelectedTable)
        {
            if (pair.Value != null)
            {
                SelectedTable[pair.Key].GetComponent<SelectionComponent>().DeSelect();
            }
        }
        SelectedTable.Clear();
    }
}