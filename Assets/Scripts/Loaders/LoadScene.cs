using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene: MonoBehaviour{

    public bool UseDelay;
    public string SceneToLoad;
    public float SecondsToDelay;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    public void Load ()
    {
        if (!UseDelay) { SceneManager.LoadScene(SceneToLoad); }
        else { StartCoroutine(DelayThenLoad()); }
    }

    public IEnumerator DelayThenLoad()
    {
        yield return new WaitForSeconds(SecondsToDelay);
        SceneManager.LoadScene(SceneToLoad);
    }
}