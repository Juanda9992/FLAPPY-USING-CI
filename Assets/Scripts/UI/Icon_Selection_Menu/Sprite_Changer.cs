using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sprite_Changer : MonoBehaviour
{
    public static Sprite_Changer sprite_Changer_inst;
    [SerializeField] private static SpriteRenderer sRenderer;
    // Start is called before the first frame update
    void Start()
    {
        if(sprite_Changer_inst == null)
        {
            sprite_Changer_inst = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        sRenderer = GetComponent<SpriteRenderer>();        
    }

    public void ChangeSprite(Image spriteImage)
    {
        sRenderer.sprite = spriteImage.sprite;
    }

}

