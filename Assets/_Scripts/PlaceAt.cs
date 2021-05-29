using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceAt : MonoBehaviour
{
    public GameObject source;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = source.transform.position;
    }
}
