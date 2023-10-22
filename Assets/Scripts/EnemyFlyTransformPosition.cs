using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer
{

    public class EnemyFlyTransformPosition : MonoBehaviour
    {
        // Start is called before the first frame update

        [SerializeField] private GameObject _hero;
        [SerializeField] private GameObject _parent;
        [SerializeField] Transform _one;
        [SerializeField] Transform _two;
        public bool _colTrig = false;
        private float _speed = 0.7f;
        private float _speed2 = 1.1f;
        private Vector3 _zeroposition;
        [SerializeField] private bool _oneBool;

        void Start()
        {
            
        }

        private void Awake()
        {

        }
       
        // Update is called once per frame
        void Update()
        {
            if (gameObject.transform.position.x != _one.transform.position.x && _oneBool == false)
            {
                gameObject.transform.position = Vector3.MoveTowards(transform.position, _one.transform.position, _speed * Time.deltaTime);
                Debug.Log("ENEMY FLY ONE");
            }

            if (gameObject.transform.position.x >=  _one.transform.position.x)
            {
                _oneBool = true;
            }

            if (_oneBool == true)
            {
                gameObject.transform.position = Vector3.MoveTowards(transform.position, _two.transform.position, _speed * Time.deltaTime);
                Debug.Log("ENEMY FLY Two");
            }
            if (gameObject.transform.position.x <= _two.transform.position.x)
            {
                _oneBool = false;
            }
            if (_colTrig == true)
            {
                gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(_hero.transform.position.x, _hero.transform.position.y+ 1,_hero.transform.position.z), _speed2 * Time.deltaTime);
            }
            if (gameObject.transform.position == _hero.transform.position)
            {
                _colTrig = false;
            }
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
