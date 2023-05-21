using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WAckSound : MonoBehaviour
{ 
    Vector3 current_position;
  [SerializeField] float direction = 1.0f;

[SerializeField] float speed = .05f;
[SerializeField]float heightlimit = 0.05f;
[SerializeField] float timecount = 0.0f;
[SerializeField] float timelimit = 0;

void Start(){
    current_position = this.transform.position;
}

void Update() {

    
 }
public bool Walk()
{
    transform.Translate (0, direction*speed*Time.deltaTime * 1, 0);


    if (transform.position.y >current_position.y+heightlimit) {
        direction = -1;
    }
    if (transform.position.y <current_position.y){
        direction = 0;
        timecount = timecount + Time.deltaTime;

        if (timecount > timelimit) {
            direction = 1;
            timecount = 0;
        }
    }
    return direction == -1f?true:direction == 1f?false:true;
}
}

