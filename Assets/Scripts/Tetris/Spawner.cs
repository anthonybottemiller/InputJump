using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] groups;

    public GameObject playArea;

    private void Start()
    {
        spawnNext();
    }

    public void spawnNext()
    {
        int i = Random.Range(0, groups.Length);

        var newShape = Instantiate(groups[i], transform.position, Quaternion.identity);
        newShape.transform.parent = playArea.transform;
    }

}
