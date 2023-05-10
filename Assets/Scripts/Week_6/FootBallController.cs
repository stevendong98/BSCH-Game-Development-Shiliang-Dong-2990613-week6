using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FootBallController : MonoBehaviour
{
    [SerializeField] Slider sliderMove;
    [SerializeField] Slider sliderForce;
    [SerializeField] Slider sliderUp;
    [SerializeField] GameObject ball;

    Rigidbody currentBall;
    // Start is called before the first frame update
    void Start()
    {
        AddBall();
    }

    void AddBall()
    {
        var b = Instantiate(ball, transform.position, Quaternion.identity);
        b.SetActive(true);
        currentBall = b.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,new Vector3(-sliderMove.value, transform.position.y, transform.position.z), Time.deltaTime * 3f);

        if (currentBall != null)
            currentBall.transform.position = transform.position;

    }


    public void Shoot()
    {
        if (currentBall == null) return;

        //currentBall.AddForce((transform.forward  * -sliderForce.value) + new Vector3(0,sliderUp.value,0));
        currentBall.velocity = new Vector3(0, sliderUp.value, -sliderForce.value); 
       // print(currentBall.velocity.y +" "+sliderUp.value);
        Destroy(currentBall.gameObject,5f);
        currentBall = null;
        Invoke("AddBall",.5f);
    }
}
