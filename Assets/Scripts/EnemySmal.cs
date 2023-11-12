using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer
{
    public class EnemySmal : MonoBehaviour
    {

        private bool pearMoveTowardsRight;
        private bool pearMoveTowardsLeft;
        private float _StartPositionX;
        private float _right;
        [SerializeField] private GameObject _bullet;
        private GameObject _bulletClone;
        [SerializeField] private GameObject _hero;
        
        void Start()
        {
            _StartPositionX = gameObject.transform.position.x;
            _right = _StartPositionX + 2;
            gameObject.GetComponent<Transform>().position = new Vector3(_StartPositionX - 2, transform.position.y, transform.position.z);
        }
        public void MoveTowardsBool()
        {
            pearMoveTowardsRight = true;

        }
        public void MoveTowardsBool2()
        {
            pearMoveTowardsRight = false;

        }

        public void MoveTowardsRight()
        {
            if (pearMoveTowardsRight == true)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(_right, gameObject.transform.position.y, 0), Time.deltaTime);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        public void MoveTowardsLeft()
        {
            if (pearMoveTowardsLeft == true)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(_StartPositionX - 1, gameObject.transform.position.y, 0), Time.deltaTime);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        public void AutoMoveTowards()
        {
            if (gameObject.GetComponent<Transform>().position.x >= _right)
            {
                pearMoveTowardsRight = false;
                pearMoveTowardsLeft = true;
            }
            if (gameObject.GetComponent<Transform>().position.x < _StartPositionX)
            {
                pearMoveTowardsRight = true;
                pearMoveTowardsLeft = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            
                if (collision.gameObject.name == "Hero")
            {
                if (gameObject.transform.position.x > _hero.transform.position.x)
                {
                    _bulletClone = Instantiate(_bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.Euler(0, 0, 0));
                    _bulletClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5, 0), ForceMode2D.Impulse);

                    if (_bulletClone.GetComponent<Rigidbody2D>().velocity.x > 0)
                    {
                        _bulletClone.GetComponent<SpriteRenderer>().flipX = false;
                    }
                    else _bulletClone.GetComponent<SpriteRenderer>().flipX = true;
                }
                if (gameObject.transform.position.x < _hero.transform.position.x)
                {
                    _bulletClone = Instantiate(_bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.Euler(0, 0, 0));
                    _bulletClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(5, 0), ForceMode2D.Impulse);
                    if (_bulletClone.GetComponent<Rigidbody2D>().velocity.x > 0)
                    {
                        _bulletClone.GetComponent<SpriteRenderer>().flipX = false;
                    }
                    else _bulletClone.GetComponent<SpriteRenderer>().flipX = true;
                }

                Destroy(_bulletClone, 1);
            }
               
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
        
        }

        private IEnumerator InfiniteLoop()
        {
            WaitForSeconds waitTime = new WaitForSeconds(2);
            while (true)
            {
                //var aa;
                Debug.Log("print.");
                yield return waitTime;
            }
        }
        // Update is called once per frame
        void Update()
        {
           
            AutoMoveTowards();
            MoveTowardsRight();
            MoveTowardsLeft();
        }
    }
}
