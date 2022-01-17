using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioClip coinSound;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(3, 6, true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(coinSound, transform.position);
        CollectableControl.coinCount++;
        Destroy(this.gameObject);
    }

}
