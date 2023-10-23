using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pizzaScript : MonoBehaviour
{
    [SerializeField] GameObject[] pizzas;
    [SerializeField] Sprite level2;
    [SerializeField] Sprite level3;



    // Start is called before the first frame update
    void Start()
    {

        

        if (GameObject.FindGameObjectWithTag("level").name == "Level 2")
        {
            for (int i = 0; i<pizzas.Length; i++)
            {
                pizzas[i].GetComponent<Image>().overrideSprite = level2;

            }

        } else if (GameObject.FindGameObjectWithTag("level").name == "Level 3")
        {
            for (int i = 0; i<pizzas.Length; i++)
            {
                pizzas[i].GetComponent<Image>().overrideSprite = level3;
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
