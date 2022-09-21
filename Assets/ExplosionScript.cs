using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public GameObject car;
    public GameObject sphere;
    Exploder exploder;
    CarMove carMove;
    int BombNumber;

    // Start is called before the first frame update
    void Start()
    {
        exploder = sphere.GetComponent<Exploder>();
        carMove = car.GetComponent<CarMove>();

        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        //BombNumber = carMove.ItemNumber;

        //if ((Input.GetKeyDown(KeyCode.I)) && (BombNumber == 6))
        //{
            //transform.position = new Vector3(15.20303f,1.452f,97.06855f);
        //}
        //else
        //{
            //sphere.SetActive (false);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plane")
        {
            exploder.enabled = true;
            //yield return new WaitForSeconds(0.5f);
            StartCoroutine(DelayCoroutine());
            //sphere.SetActive (false);
        }
    }

    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        sphere.SetActive (false);
    }
}
