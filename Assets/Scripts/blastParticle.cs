using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blastParticle : MonoBehaviour
{

    public int destoryAfterSec;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(matikan());
    }

    IEnumerator matikan() {
        yield return new WaitForSeconds(destoryAfterSec);
        Destroy(this.gameObject);
    }
}
