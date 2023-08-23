using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sprite_Changer : MonoBehaviour
{
    public SpriteRenderer sRenderer;
    [SerializeField] private Sprite defaultSprite;
    private SaveDataHolder dataHolder;
    // Start is called before the first frame update
    void Start()
    {
        dataHolder = GameObject.FindObjectOfType<SaveDataHolder>();
        sRenderer = GetComponent<SpriteRenderer>();    
    }

    public void ChangeSprite(Image spriteImage)
    {
        sRenderer.sprite = spriteImage.sprite;
    }

    public void SaveSprite(int spriteIndex)
    {
        dataHolder.data.spriteIndex = spriteIndex;
    }

}

