using UnityEngine;
using System.Collections;

public class AttackGiant : MonoBehaviour {

    public int _powerAttack = 2000;
    public GameObject _powerObjectInstantiate;
    public Transform positionCam;

    private bool checkCountDownAttackGiant;
    private Hashtable _hashPowerObject;
    private float timeCheckAttackGiant;

	// Use this for initialization
	void Start () {

        timeCheckAttackGiant = 0;
        checkCountDownAttackGiant = true;

        if (!_powerObjectInstantiate)
        {
            print("We're not found ObjectAttack.");
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0) && checkCountDownAttackGiant == true)
        {

            checkCountDownAttackGiant = false;
            print("In OnMouseDown");
            Instantiate(_powerObjectInstantiate, new Vector3(positionCam.transform.position.x, positionCam.transform.position.y,
                       positionCam.transform.position.z), positionCam.transform.rotation);

        }
        else if (checkCountDownAttackGiant == false)
        {
            timeCheckAttackGiant += Time.deltaTime;
            if (timeCheckAttackGiant >= 0.5f)
            {
                checkCountDownAttackGiant = true;
                timeCheckAttackGiant = 0;
            }
        }

	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "HumanPlayer")
        {

        }
    }

}
