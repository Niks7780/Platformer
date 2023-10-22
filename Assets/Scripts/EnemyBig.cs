using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer
{
    public class EnemyBig : MonoBehaviour
    {
        private float _x;
        static internal int _xx = 5;
        [SerializeField] private float _moving = 3;
        private bool ispearmoveright;
        private bool ispearmoveleft;
        private float _right;
        private float _StartPositionX;
        public Hero _hero;
        public float _speed = 5;
        public bool _canAttack;
        [SerializeField] private bool _seeHero = false;
        void Start()
        {
            _x = gameObject.transform.position.x;
            _StartPositionX = gameObject.transform.position.x;
            _right = _StartPositionX + _moving;
            gameObject.GetComponent<Transform>().position = new Vector3(_StartPositionX - 2, transform.position.y, transform.position.z);
        }

        private void Awake()
        {
            // _sprite = GetComponentInChildren<SpriteRenderer>();
            
        }
        public void AutoTransformPosition()
        {
            if (gameObject.GetComponent<Transform>().position.x >= _right && _seeHero == false)
            {
                ispearmoveright = false;
                ispearmoveleft = true;
            }
            if (gameObject.GetComponent<Transform>().position.x < _StartPositionX && _seeHero == false)
            {
                ispearmoveright = true;
                ispearmoveleft = false;
            }
        }
        public void TransformPositionRight()
        {
            
            _x = _x + 0.003f;
            gameObject.GetComponent<Transform>().position = new Vector3(_x, transform.position.y, transform.position.z);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        public void TransformPositionLeft()
        {
            
            _x = _x - 0.003f;
            gameObject.GetComponent<Transform>().position = new Vector3(_x, transform.position.y, transform.position.z);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
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

       

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == "Hero")
            {
                _seeHero = true;
                GoHero();
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.name == "Hero")
            {
                _seeHero = false;
                _canAttack = false;
            }
        }
       
        private void AttackHero()
        {
           if (gameObject.transform.position.x < _hero.transform.position.x)
           {
              if (_hero.transform.position.x - gameObject.transform.position.x < 1.5f)
              {
                    _canAttack = true;
                   
                    gameObject.transform.position = new Vector3(_hero.transform.position.x - 1.5f, transform.position.y, transform.position.z);
                    
              }
           }
                if (_hero.transform.position.x < gameObject.transform.position.x)
                {
                    if (gameObject.transform.position.x - _hero.transform.position.x < 1.5f)
                    {
                        _canAttack = true;
                    gameObject.transform.position = new Vector3(_hero.transform.position.x - 1.5f, transform.position.y, transform.position.z);
                }
                }
        }
        private void GoHero()
        {
            if (_seeHero == true && _canAttack == false)
                gameObject.transform.position = Vector3.MoveTowards(transform.position, _hero.transform.position, _speed * Time.deltaTime);
            Debug.Log("GO HERo");
        }
        void Update()
        {
            //GoHero();
            AttackHero();
            AddTransformUpdate();
            AutoTransformPosition();
            
        }
    }
}