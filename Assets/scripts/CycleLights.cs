using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleLights : MonoBehaviour
{
    public Light[] lights;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cycleLights());
    }

    IEnumerator cycleLights()
    {
        var index = 0;
        while (true)
        {
            for (var i = 0; i < this.lights.Length; i++)
            {
                this.lights[i].enabled = (i == index);
            }
            index = (index + 1) % (this.lights.Length);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
