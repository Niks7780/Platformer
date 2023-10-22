using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer
{

    public class EnemyFly : MonoBehaviour
    {
        // Start is called before the first frame update

        [SerializeField] private GameObject _hero;
        [SerializeField] private GameObject _parent;
        private float _x;
        private float _y;
        private bool ispearmoveright;
        private bool ispearmoveleft;
        private float _right;
        private float _StartPositionX;
        private bool _colTrig;
        [SerializeField] private float _speed = 0.001f;
        private Vector3 _zeroposition;

        void Start()
        {
            _StartPositionX = gameObject.transform.position.x;
            _y = gameObject.transform.position.y;
            _right = _StartPositionX + 5;
            gameObject.GetComponent<Transform>().position = new Vector3(_StartPositionX - 2, transform.position.y, transform.position.z);
        }

        private void Awake()
        {
            
        }
        public void AutoTransformPosition()
        {
            if (gameObject.GetComponent<Transform>().position.x >= _right)
            {
                ispearmoveright = false;
                ispearmoveleft = true;
            }
            if (gameObject.GetComponent<Transform>().position.x < _StartPositionX)
            {
                ispearmoveright = true;
                ispearmoveleft = false;
            }
        }
        public void TransformPositionRight()
        {
            _x = gameObject.transform.position.x + 0.005f;
            _y = _y + 0.001f;
            gameObject.GetComponent<Transform>().position = new Vector3(_x, _y, transform.position.z);
            
        }
        public void TransformPositionLeft()
        {
            _x = _x - 0.005f;
            _y = _y - 0.001f;
            gameObject.GetComponent<Transform>().position = new Vector3(_x, _y, transform.position.z);
           
        }


        public void AddTransformUpdate()
        {
            if (ispearmoveright == true)
            {
                TransformPositionRight();
            }
            if (ispearmoveleft == true)
            {
                TransformPositionLeft();
            }
        }
        // Update is called once per frame
        void Update()
        {
            if (_colTrig == false)
            {
                AddTransformUpdate();
                AutoTransformPosition();
            }
            if (_colTrig == true)
            {
                _parent.transform.position = Vector3.MoveTowards(transform.position, _hero.transform.position, _speed * Time.deltaTime);
            }
            //CalculatorDistance();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == "Hero") 
            {
                _colTrig = true;
                _zeroposition = _parent.transform.position;
                
            }
            
        }
        public void CalculatorDistance()
        {
            float _dist = Vector3.Distance(gameObject.transform.position, _hero.transform.position);
            Debug.Log("ENEMY FLY" + _dist);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.name == "Hero")
            {
                _colTrig = false;

                //_parent.transform.position = Vector3.MoveTowards(transform.position, _parent.transform.position, _speed * Time.deltaTime);
            }
        }
        // Update is called once per frame
        
    }
}
