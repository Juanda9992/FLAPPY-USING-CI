using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Holder : MonoBehaviour
{
    public static Sprite_Holder sprite_Holder_inst;
    public Sprite currentSprite;
    [SerializeField] public Sprite[] avaliableSprites;
    // Start is called before the first frame update
    void Awake()
    {
        if(sprite_Holder_inst == null)
        {
            sprite_Holder_inst = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        sprite_Holder_inst.currentSprite = avaliableSprites[PlayerPrefs.GetInt("Icon")];
    }
}
