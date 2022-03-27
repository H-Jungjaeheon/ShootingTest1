using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyEffects());
    }
    IEnumerator DestroyEffects()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
