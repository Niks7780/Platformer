using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer 
{
    public class Control : MonoBehaviour
    {
        public GameObject titl1;
        public GameObject titl2;
        public GameObject titl3;
        public GameObject titl4;
        public GameObject titl5;
        public GameObject titl6;
        public GameObject titl7;
        public GameObject titl8;
        public GameObject titl9;
        public GameObject titl10;
        public GameObject titl11;
        private GameObject titl1Clone1;
        private GameObject titl1Clone2;
        private GameObject titl1Clone3;
        private GameObject titl1Clone4;
        private GameObject titl1Clone5;
        private GameObject titl1Clone6;
        private GameObject titl1Clone7;
        private GameObject titl1Clone8;
        private GameObject titl1Clone9;
        private GameObject titl1Clone10;
        private GameObject titl1Clone10a;
        private GameObject titl1Clone11;
        private GameObject titl1Clone12a;
        private GameObject titl1Clone12;
        private GameObject titl1Clone13;
        private GameObject titl1Clone14;
        private GameObject titl1Clone15;
        private GameObject titl1Clone16;
        private GameObject titl1Clone17;
        private GameObject titl1Clone18;
        private GameObject titl1Clone18a;


        private bool transformTitl = true;
        private bool transformTitl2;
        void Start()
        {
            InputTitls();
            
        }

        private void InputTitls()
        {
            titl1Clone1 = Instantiate(titl1, new Vector3(-10, -2, 0), Quaternion.Euler(0, 0, 0));
            titl1Clone2 = Instantiate(titl1, new Vector3(-7.2f, -2, 0), Quaternion.Euler(0, 0, 0));
            titl1Clone3 = Instantiate(titl1, new Vector3(-4.4f, -2, 0), Quaternion.Euler(0, 0, 0));
            titl1Clone4 = Instantiate(titl1, new Vector3(-1.6f, -2, 0), Quaternion.Euler(0, 0, 0));
            titl1Clone5 = Instantiate(titl1, new Vector3(3.8f, -2, 0), Quaternion.Euler(0, 0, 0));
            titl1Clone6 = Instantiate(titl1, new Vector3(7.2f, -2, 0), Quaternion.Euler(0, 0, 0));
            titl1Clone7 = Instantiate(titl1, new Vector3(20, -2, 0), Quaternion.Euler(0, 0, 0));
            titl1Clone8 = Instantiate(titl1, new Vector3(20, -3, 0), Quaternion.Euler(0, 0, 0));
            titl1Clone9 = Instantiate(titl1, new Vector3(23, 4, 0), Quaternion.Euler(0, 0, 0));
            titl1Clone10 = Instantiate(titl4, new Vector3(26, 4, 0), Quaternion.Euler(0, 0, 0));
            titl1Clone11 = Instantiate(titl1, new Vector3(29, 4, 0), Quaternion.Euler(0, 0, 0));
            titl1Clone12 = Instantiate(titl5, new Vector3(32, 4, 0), Quaternion.Euler(0, 0, 0));
            titl1Clone13 = Instantiate(titl1, new Vector3(35, 4, 0), Quaternion.Euler(0, 0, 0));
            titl1Clone14 = Instantiate(titl6, new Vector3(38, 4, 0), Quaternion.Euler(0, 0, 0));
            titl1Clone15 = Instantiate(titl1, new Vector3(41, 4, 0), Quaternion.Euler(0, 0, 0));
            titl1Clone16 = Instantiate(titl7, new Vector3(44, 4, 0), Quaternion.Euler(0, 0, 0));
            titl1Clone17 = Instantiate(titl1, new Vector3(47, 7, 0), Quaternion.Euler(0, 0, 0));
            titl1Clone18 = Instantiate(titl8, new Vector3(50, 10, 0), Quaternion.Euler(0, 0, 0));

        }

        private void TransformTitle()
        {
            if (transformTitl == true)
            {
                titl1Clone7.transform.position = Vector3.MoveTowards(titl1Clone7.transform.position, new Vector3(10f, -2, 0), Time.deltaTime*2);
                titl1Clone8.transform.position = Vector3.MoveTowards(titl1Clone8.transform.position, new Vector3(20f, -2, 0), Time.deltaTime*2);
            }
            if (transformTitl2 == true)
            { 
                titl1Clone7.transform.position = Vector3.MoveTowards(titl1Clone7.transform.position, new Vector3(20f, -2, 0), Time.deltaTime*2);
                titl1Clone8.transform.position = Vector3.MoveTowards(titl1Clone8.transform.position, new Vector3(20f, 5, 0), Time.deltaTime*2);
            }
        }
        private void TransformTitleBool()
        {
            if (titl1Clone7.transform.position.x <=10)
            {
                transformTitl = false;
                transformTitl2 = true;
            }
            if (titl1Clone7.transform.position.x >= 20)
            {
                transformTitl = true;
                transformTitl2 = false;
            }
        }

        // Update is called once per frame
       


        void Update()
        {
            TransformTitle();
            TransformTitleBool();
        }
    } 
}
