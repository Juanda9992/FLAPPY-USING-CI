using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Link : MonoBehaviour
{
    public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }
}
