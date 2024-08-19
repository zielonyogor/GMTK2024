using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevels : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < GameManager.Instance.gameData.level; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;

            if (GameManager.Instance.gameData.completedWithSpecial[i] == true)
            {
                transform.GetChild(i).GetChild(1).gameObject.SetActive(true);
            }
        }
    }
}
