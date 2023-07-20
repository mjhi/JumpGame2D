using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBase : MonoBehaviour
{
    public float mobSpeed = 0;
    public Vector2 StartPosition;
    void OnEnable()
    {
        transform.position = StartPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isPlay){
            transform.Translate(Vector2.left*Time.deltaTime*GameManager.instance.gameSpeed);

            if(transform.position.x<-2.5)
            {
                gameObject.SetActive(false);
            }
        }
        
    }
}
