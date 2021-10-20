using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class Creature2 : MonoBehaviour
{
    public Vector3 Location { get; set; }

    private void Start()
    {

    }

    private void Update()
    {
        Location = this.transform.position;
    }
}
