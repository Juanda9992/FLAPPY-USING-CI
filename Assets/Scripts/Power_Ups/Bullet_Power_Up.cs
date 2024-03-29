using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Power_Up : MonoBehaviour, IPickable
{
    private Player_Shoot player_Shoot;
    public void OnPicked()
    {
        GameObject.FindObjectOfType<Player_Shoot>().IncreaseAmmo();
        SaveDataHolder.instance.data.bombsTaken++;
        Audio_Manager.instance.PlaySound("PowerUp");
        Destroy(this.gameObject);
    }
}
