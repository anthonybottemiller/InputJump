using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBeeper : MonoBehaviour {
    public AudioClip HighBeep;
    public AudioClip LowBeep;

    public GameObject Prefab;



    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Beep()
    {
        int choice = Random.Range(0, 2);
        if(choice == 0)
        {
            GameObject NewObject = CreateSource();
            AudioSource NewSource = NewObject.GetComponent<AudioSource>();
            NewSource.clip = HighBeep;
            NewSource.Play();
            StartCoroutine(DestroyAfterPlay(NewObject));
        }
        else
        {
            GameObject NewObject = CreateSource();
            AudioSource NewSource = NewObject.GetComponent<AudioSource>();
            NewSource.clip = LowBeep;
            NewSource.Play();
            StartCoroutine(DestroyAfterPlay(NewObject));
        }
    }
    bool IsPlaying(AudioSource audioSource)
    {
        return false;
    }
    public GameObject CreateSource()
    {
        GameObject SoundObject = Instantiate<GameObject>(Prefab);
        return SoundObject;
    }

    IEnumerator DestroyAfterPlay(GameObject NewObject)
    {
        AudioSource audioSource = NewObject.GetComponent<AudioSource>();

        yield return new WaitUntil(() => !audioSource.isPlaying);
        Destroy(NewObject);
    }
}
