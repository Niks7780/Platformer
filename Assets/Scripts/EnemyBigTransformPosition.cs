using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer
{

    public class EnemyBigTransformPosition : MonoBehaviour
    {
        // Start is called before the first frame update

        [SerializeField] private GameObject _hero;
        static internal int _xx = 5;
        [SerializeField] private Transform _right;
        [SerializeField] private Transform _left;
        public bool _colTrig = false;
        private float _speed = 0.7f;
        private float _speed2 = 1.1f;
        private Vector3 _zeroposition;
        [SerializeField] private bool _oneBool;
        public GameObject _attack;
        private GameObject _attackClone;

        void Start()
        {
            _left.transform.position = new Vector3(_left.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            _right.transform.position = new Vector3(_right.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        private void Awake()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (gameObject.transform.position.x != _right.transform.position.x && _oneBool == false && _colTrig == false)
            {
                gameObject.transform.position = Vector3.MoveTowards(transform.position, _right.transform.position, _speed * Time.deltaTime);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }

            if (gameObject.transform.position.x >= _right.transform.position.x - 1)
            {
                _oneBool = true;
            }

            if (_oneBool == true)
            {
                gameObject.transform.position = Vector3.MoveTowards(transform.position, _left.transform.position, _speed * Time.deltaTime);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            if (gameObject.transform.position.x <= _left.transform.position.x + 1)
            {
                _oneBool = false;
            }
            if (_colTrig == true && gameObject.transform.position.x > _hero.transform.position.x)
            {
                gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(_hero.transform.position.x + 2f, gameObject.transform.position.y, gameObject.transform.position.z), _speed2 * Time.deltaTime);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                if (gameObject.transform.position.x == _hero.transform.position.x + 2f)
                {
                    StartCoroutine(AttackLeft());
                }
            }
            if (_colTrig == true && gameObject.transform.position.x < _hero.transform.position.x)
            {
                gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(_hero.transform.position.x - 2f, gameObject.transform.position.y, gameObject.transform.position.z), _speed2 * Time.deltaTime);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                if (gameObject.transform.position.x == _hero.transform.position.x - 2f)
                {
                    StartCoroutine(AttackRight());
                }
            }
            if (gameObject.transform.position.x != _hero.transform.position.x + 2f)
            {
                StopCoroutine(AttackLeft());
            }
            if (gameObject.transform.position.x != _hero.transform.position.x - 2f)
            {
                StopCoroutine(AttackRight());
            }
        }
        IEnumerator AttackRight()
        {
            yield return new WaitForSeconds(3f);
            Debug.Log("AttackRight()");
            if (GameObject.Find("AttackEnemyBig(Clone)") == null) 
            { 
                _attackClone = Instantiate(_attack, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.Euler(0, 0, 90));
                _attackClone.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 10);
                Destroy(_attackClone, 1f); 
            }

            
        }
        IEnumerator AttackLeft()
        {
            
           
            if (GameObject.Find("AttackEnemyBig(Clone)") == null)
            {
                _attackClone = Instantiate(_attack, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.Euler(0, 0, 90));
                _attackClone.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 90);
                Destroy(_attackClone, 1f);
                Debug.Log("AttackLeft()");
            }
            yield return new WaitForSeconds(3f);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == "Hero")
            {
                _colTrig = true;

            }

        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.name == "Hero")
            {
                _colTrig = false;
                
            }
        }
        // Update is called once per frame

    }
}
