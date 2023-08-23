using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Holder : MonoBehaviour
{
    public Sprite currentSprite;
    [SerializeField] public Sprite[] avaliableSprites;
    // Start is called before the first frame update
    void Awake()
    {
    }
}
