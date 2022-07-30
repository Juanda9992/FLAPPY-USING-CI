using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sprite_Changer : MonoBehaviour
{
    public SpriteRenderer sRenderer;
    [SerializeField] private Sprite defaultSprite;
    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();     
    }

    public void ChangeSprite(Image spriteImage)
    {
        sRenderer.sprite = spriteImage.sprite;
        Sprite_Holder.sprite_Holder_inst.currentSprite = spriteImage.sprite;
    }

}

