using UnityEngine;

[CreateAssetMenu(fileName = "SaveModel", menuName = "Save Data/SaveModel", order = 0)]
public class SaveModel : ScriptableObject 
{
    public float musicVolume;
    public float sfxVolume;
    public bool vSyncActive = true;    
}