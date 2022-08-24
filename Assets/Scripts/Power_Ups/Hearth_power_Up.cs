using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearth_power_Up : MonoBehaviour, IPickable
{
    public void OnPicked()
    {
        GameObject.FindObjectOfType<Player_Jump>().health ++;
        Stats_Handler.stats_Handler_inst.totalHearts++;
        Audio_Manager.instance.PlaySound("PowerUp");
        Destroy(this.gameObject);
    }
}
