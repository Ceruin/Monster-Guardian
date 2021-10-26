using UnityEngine;

public class Consumable : MonoBehaviour
{
    // Restriction

    public int HungerValue { get; set; } // Amount Hunger
    public int LifeValue { get; set; }  // Amount Life

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    // todo: some method that will allow you to get the value to reduce the creatures hunger by and then decrement the foods life by
}