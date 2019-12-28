using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private GameObject mainFish;
    [SerializeField]
    private GameObject topCoral;
    [SerializeField]
    private GameObject bottomCoral;
    
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        StartCoroutine(CoralSpawnRoutine());
    }

    public void StartSpawnRoutines()
    {
        StartCoroutine(CoralSpawnRoutine());
    }

    IEnumerator CoralSpawnRoutine()
    {
        while (_uiManager.gameOver == false)
        {
            float bottomCoralYValue = Random.Range(-10f, -3f);
            Instantiate(bottomCoral, new Vector3(10f, bottomCoralYValue, 0), Quaternion.identity);
            Instantiate(topCoral, new Vector3(10f, bottomCoralYValue + 14, 0), Quaternion.identity);
            yield return new WaitForSeconds(3.0f);
        }
    }

}
