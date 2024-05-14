using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private int UICounter = 0;
    public List<GameObject> cellsUI;


    public void Start()
    {
        for (int i = 0; i < cellsUI.Count; i++)
        {
            cellsUI[i].SetActive(false);
        }
    }

    public void UIAugmenter()
    {
        cellsUI[UICounter].SetActive(true);
        UICounter++;
    }
}
