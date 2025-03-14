using UnityEngine;
using System.Collections.Generic;
using _Scripts.Utils;

public class BrickColourManager : SingletonMonoBehavior<BrickColourManager>
{
    [SerializeField] private List<Color> brickColors = new List<Color>
    {
        Color.red,
        Color.blue,
        Color.green,
        Color.yellow,
        new Color(1f, 0.5f, 0f),  // Orange
        new Color(0.5f, 0f, 0.5f) // Purple
    };

    public Color GetRandomColor()
    {
        int randomIndex = Random.Range(0, brickColors.Count);
        return brickColors[randomIndex];
    }
}