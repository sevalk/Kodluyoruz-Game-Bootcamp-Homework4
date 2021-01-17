using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private ExampleSceneLoader _exampleSceneLoader;
    private void Start()
    {
        _exampleSceneLoader = FindObjectOfType<ExampleSceneLoader>();
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Wait());
        
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        _exampleSceneLoader.LoadGameOverScene();
    }
}
