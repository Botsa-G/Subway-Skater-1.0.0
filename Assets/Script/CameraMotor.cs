﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

    private int selected;
    public Transform[] lookAt; //Object looking at
    public Vector3 offset = new Vector3(0, 5.0f, -10.0f);
    public Vector3 rotation = new Vector3(35, 0, 0);

    public bool IsMoving { set; get; }

    private void Awake()
    {
        selected =  PlayerPrefs.GetInt("CharacterChoice");
    }
    private void LateUpdate()
    {
        if (!IsMoving)
            return;

        Vector3 desiredPosition = lookAt[selected].position + offset;
        desiredPosition.x = 0;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, 0.1f);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotation), Time.deltaTime);
    }
}
