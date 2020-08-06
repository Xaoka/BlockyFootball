using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Material[] options;
    public MeshRenderer renderTarget;

    // Start is called before the first frame update
    void Start()
    {
        if (this.options.Length == 0) { return; }
        var index = Random.Range(0, this.options.Length);
        this.renderTarget.material = this.options[index];
    }
}
