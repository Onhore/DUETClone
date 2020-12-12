using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splatter : MonoBehaviour
{
    [Header("Splatter options")]
    [SerializeField] private Color[] Colors = new Color[2];
    [SerializeField] private GameObject SplatterPrefab;
    [SerializeField] private Sprite[] splatterSprites;

    public void AddSplatter(Transform obstacle, Vector3 position, int colorIndex)
    {
        var splatter = Instantiate
        (
            SplatterPrefab,
            position,
            Quaternion.Euler(new Vector3(0f, 0f, Random.Range(-320f, 320f))),
            obstacle
        );

        var spriteRenderer = splatter.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Colors[colorIndex];
        spriteRenderer.sprite = splatterSprites [Random.Range(0, splatterSprites.Length)];
    }

}
