using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shift : MonoBehaviour
{
    public int moveDistance = 108;
    public void Move()
    {
        this.gameObject.transform.position = this.gameObject.transform.position + this.gameObject.transform.forward * moveDistance;
    }
}
