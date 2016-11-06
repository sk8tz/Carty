﻿using UnityEngine;
using System.Collections;
using CartyLib;
using Testing;

[IntegrationTest.DynamicTest("CartyLibTests")]
class CanBeMovedDestroyDuringMovement : MonoBehaviour
{
    private int UpdateCount { get; set; }
    private GameObject _card;

    void Start()
    {
        UpdateCount = 0;
        _card = CardsGameObjects.OnlyDetachHandle();
        var move = _card.AddComponent<CartyLib.CardsComponenets.CanBeMoved>();
        _card.transform.position = Vector3.one;
        move.Move(Vector3.one);
        move.Rotate(Quaternion.Euler(45, 0, 90));
    }

    void Update()
    {
        if (UpdateCount == 0)
        {
            Destroy(_card);
            IntegrationTest.Pass(gameObject);
        }

        UpdateCount++;
    }

}
