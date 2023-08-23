using UnityEngine;

[CreateAssetMenu(fileName = "SaveModel", menuName = "Save Data/SaveModel", order = 0)]
public class SaveModel : ScriptableObject 
{
    public int spriteIndex;
    [Header("Settings")]
    [Range(-80,0)]
    public float musicVolume;
    [Range(-80,0)]
    public float sfxVolume;
    public bool vSyncActive = true;    
}