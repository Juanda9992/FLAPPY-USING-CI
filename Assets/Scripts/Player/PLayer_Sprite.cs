using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer_Sprite : MonoBehaviour
{
    [SerializeField] private DataSprite allSprites;
    [SerializeField] private SaveModel data;

    private void Start() 
    {
        GetComponent<SpriteRenderer>().sprite = allSprites.GetSprite(data.spriteIndex);    
    }
}
