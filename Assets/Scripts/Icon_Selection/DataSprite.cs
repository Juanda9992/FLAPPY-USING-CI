using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataSprite", menuName = "Sprites/DataSprite", order = 0)]
public class DataSprite : ScriptableObject 
{
    public List<Sprite> allSprites = new List<Sprite>();

    public Sprite GetSprite(int index)
    {
        return allSprites[index];
    }    
}
