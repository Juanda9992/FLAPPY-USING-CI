using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    public int ammo = 0;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K) && ammo >0)
        {
            Shoot();
        }       
    }

    private void Shoot()
    {
        ammo --;
        Instantiate(bulletPrefab,new Vector2(transform.position.x +1, transform.position.y),Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<IPickable>(out IPickable pickable))
        {
            
            pickable.OnPicked();
        }
    }
}
