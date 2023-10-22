using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class MainCamera : MonoBehaviour
    {
        public GameObject hero;
        // Start is called before the first frame update
        void Start()
        {

        }
        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(hero.transform.position.x, hero.transform.position.y, -20);
        }
    }
}
