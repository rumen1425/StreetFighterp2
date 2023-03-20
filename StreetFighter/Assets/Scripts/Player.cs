using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public class Player_
    {
        int maxhealth = 150;
        int currenthealth;

        Player_()
        {
            this.maxhealth = maxhealth;
            this.currenthealth = currenthealth;
        }

        void TakeDamage()
        {

        }

        void OnCollisionEnter2D()
        {
            
        }
    }
}
