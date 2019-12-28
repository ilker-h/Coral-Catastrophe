using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCoral : MonoBehaviour
{

    private UIManager _uiManager;
    
    [SerializeField]
    private float _coralSpeed = 3f;

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
        // when coral passes the fish, increase score by 1
        if (transform.position.x > -3.05 && transform.position.x < -3.0f)
        {
           _uiManager.UpdateScore();
        }
    }

}
