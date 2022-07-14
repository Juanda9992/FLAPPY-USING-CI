using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spam_Obstacle : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToDuplicate;
    [SerializeField]
    public int maxTimesToDuplicate = 10;
    [SerializeField]
    public int currentDuplicateNumber;
    Gravity_Switcher switcher;

    void Start()
    {
        switcher = GetComponent<Gravity_Switcher>();
        duplicateObstacle();
        transform.localScale = new Vector2(transform.lossyScale.x,transform.lossyScale.y * switcher.gravityAxis);
    }
    public void duplicateObstacle()
    {
        currentDuplicateNumber = Random.Range(3,maxTimesToDuplicate);
        for(int i = 0;i< currentDuplicateNumber;i++)
        {
            if(objectToDuplicate != null)
            {
                GameObject currentClone = Instantiate(objectToDuplicate, new Vector2(transform.position.x + i,transform.position.y),Quaternion.identity);
                currentClone.transform.SetParent(this.transform);
            }
        }
    }
}
