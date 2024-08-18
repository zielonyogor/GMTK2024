using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class Finish : MonoBehaviour
{
    [SerializeField] PlayerInput input;

    [SerializeField] Image blackScreen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(FadeScreen());
    }

    private IEnumerator FadeScreen()
    {
        input.enabled = false;
        for (var t = 0.0f; t < 1.0f; t += Time.deltaTime / 1f)
        {
            Color newColor = new Color(0f, 0f, 0f, Mathf.Lerp(0, 1f, t));
            blackScreen.color = newColor;
            yield return null;
        }
        //yield return new WaitForSeconds(0.05f);
        GameManager.Instance.NextLevel();
    }
}
