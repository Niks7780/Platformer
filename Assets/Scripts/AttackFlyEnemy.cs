using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer
{
    public class AttackFlyEnemy : MonoBehaviour
    {
        // Start is called before the first frame update
        public Hero _hero;
        public GameObject _parent;
        
        void Start()
        {

        }
        private void OnTriggerEnter2D(Collider2D col)
        {

            if (col.gameObject.name == "Hero")
            {
                _hero.GetDamage();
                _parent.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            }
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
