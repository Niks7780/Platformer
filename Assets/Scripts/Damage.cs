using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer
{
    public class Damage : MonoBehaviour
    {
        // Start is called before the first frame update
        public Hero _hero;
        void Start()
        {

        }
        private void OnCollisionEnter2D(Collision2D col)
        {

            if (col.gameObject.name == "Hero")
            {
                _hero.GetDamage();
            }
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}

