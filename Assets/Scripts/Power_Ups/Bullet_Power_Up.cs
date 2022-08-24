using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Power_Up : MonoBehaviour, IPickable
{
    private Player_Shoot player_Shoot;
    public void OnPicked()
    {
        GameObject.FindObjectOfType<Player_Shoot>().IncreaseAmmo();
        Stats_Handler.stats_Handler_inst.totalBombs++;
        Audio_Manager.instance.PlaySound("PowerUp");
        Destroy(this.gameObject);
    }
}
