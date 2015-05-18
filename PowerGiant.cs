using UnityEngine;
using System.Collections;

public class PowerGiant : MonoBehaviour {

    public int _power;
   public Transform positionGoal;

    private AttackGiant _attackGiant;

	// Use this for initialization
	void Start () {

        _attackGiant = new AttackGiant();
        _power = _attackGiant._powerAttack;
        //positionGoal = _attackGiant.positionGoal.transform.position;
        print("PowerGiant : " + _power);

        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * _power, ForceMode.Acceleration);
            
	}
	
	// Update is called once per frame
	void Update () {

        //gameObject.transform.rotation = _attackGiant.positionGoal;
       

	}
}
