using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCoral : MonoBehaviour
{

    [SerializeField]
    private float _coralSpeed = 3f;
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _coralSpeed * Time.deltaTime);
        if (transform.position.x < -10 || _uiManager.gameOver == true)
        {
            Destroy(this.gameObject);
        }
    }
}
