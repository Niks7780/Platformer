using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer
{
    public class DamageEnemy : MonoBehaviour
    {
                
        void Start()
        {

        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Enemy")
            {
                Destroy(col.gameObject);
            }
            if (col.gameObject.tag == "EnemySmal")
            {
                Destroy(col.gameObject);
            }
            if (col.gameObject.tag == "EnemyFly")
            {
                GameObject _fly = GameObject.Find("EnemyFly");

                Destroy(_fly);

            }
            if (col.gameObject.tag == "EnemyBig")
            {
                EnemyBigTransformPosition._xx = EnemyBigTransformPosition._xx - 1;
                if (EnemyBigTransformPosition._xx <= 0)
                {
                    Destroy(col.gameObject);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
