using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipScript : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] sides;
    int flipCount = 1;

    private void OnMouseDown()
    {
        StartCoroutine(WaitPlease(0.0001f, 1.0f));
    }

    IEnumerator WaitPlease(float duration, float size)
    {
        while(size > 0.1)
        {
            size = size - 0.07f;
            transform.localScale = new Vector3(1, size, 1);
            yield return new WaitForSeconds(duration);
        }
        spriteRenderer.sprite = sides[flipCount % 2];
        while (size < 0.99)
        {
            size = size + 0.07f;
            transform.localScale = new Vector3(1, size, size);
            yield return new WaitForSeconds(duration);
        }
        flipCount++;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
