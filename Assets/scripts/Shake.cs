using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        this.startPosition = this.gameObject.transform.localPosition;
    }

    public void shakeForSeconds(float time)
    {

        StartCoroutine(shakeRoutine(time));
    }

    IEnumerator shakeRoutine(float time)
    {
        while (time > 0f)
        {
            time -= Time.deltaTime;
            Vector3 offset = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            this.transform.localPosition = this.startPosition + (offset * 0.05f);
            yield return new WaitForSeconds(0.025f);
        }
    }
}
