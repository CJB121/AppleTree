﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;




    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++ )
        {
            GameObject tBasketGo = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGo.transform.position = pos;
            basketList.Add(tBasketGo);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AppleDestroyed()
    {
        //destroy all the falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        //destroy one of the baskets
        // get the index of the last basket in basketlist
        int basketIndex = basketList.Count - 1;
        // get a reference to the basket GameObject
        GameObject tbasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tbasketGO);
        if (basketList.Count == 0)
        {
            //Application.LoadLevel("Level_1");
            SceneManager.LoadScene("Level_1");
        }
    }
}
