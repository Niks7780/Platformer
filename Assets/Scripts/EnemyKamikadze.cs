using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer
{
    public class EnemyKamikadze : MonoBehaviour
    {
        [SerializeField] private GameObject _hero;
        [SerializeField] private GameObject _parent;
        [SerializeField] private int _speed = 2;
        private bool _go = false;


        // Start is called before the first frame update
        void Start()
        {

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Hero") Destroy(gameObject);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {

            //if (collision.gameObject.name == "Hero" && gameObject.transform.position.x > _hero.transform.position.x) _parent.GetComponent<Rigidbody2D>().AddForce(new Vector3(_hero.transform.position.x, transform.position.y, transform.position.z), ForceMode2D.Impulse);
            //if (collision.gameObject.name == "Hero" && gameObject.transform.position.x < _hero.transform.position.x) _parent.GetComponent<Rigidbody2D>().AddForce(new Vector3(-_hero.transform.position.x, transform.position.y, transform.position.z), ForceMode2D.Impulse);
            if (collision.gameObject.name == "Hero") _go = true;
        }
        
        private void Attack()
        {
            _parent.transform.position = Vector3.MoveTowards(transform.position, _hero.transform.position, _speed * Time.deltaTime);
        }
        private void Wait()
        {
            _parent.transform.position = transform.position;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            //if (collision.gameObject.name == "Hero") _parent.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            _go = false;
        }
        // Update is called once per frame
        void Update()
        {
            if (_go == true) Attack();
            if (_go == false) Wait();
            if (gameObject.GetComponent<Rigidbody2D>().velocity.x > 0) gameObject.GetComponent<SpriteRenderer>().flipX = false;
            if (gameObject.GetComponent<Rigidbody2D>().velocity.x < 0) gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
