using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private ScoreManager scoreManager;
    public AudioClip collectSound;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            if (gameObject.tag=="RedFlowers")
                scoreManager.IncrementScoreBy1();
            else if (gameObject.tag=="BlueFlowers")
                scoreManager.IncrementScoreBy3();

            AudioSource.PlayClipAtPoint(collectSound,transform.position);
            gameObject.SetActive(false);
        }
    }
}
