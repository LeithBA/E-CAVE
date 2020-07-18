using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Kinect = Windows.Kinect;


public class CaveManager : MonoBehaviour
{
    public Transform screenContainer;
    private Transform head, bodyView;
    private List<CaveScreen> screens = new List<CaveScreen>();

    public float scale = 1;

    private void Start()
    {
        var screenCount = 0;
        foreach (Transform screen in screenContainer)
        {
            screenCount++;
            screens.Add(new CaveScreen(screen, screenCount));
        }


        bodyView = this.transform.Find("BodyView");
        bodyView.GetComponent<BodySourceView>().scaleMult = scale;
    }

    private void Update()
    {
        if (!head)
        {
            FindHead();
            if (!head) return;
        }

        UpdateCamera();

    }

    private void FindHead()
    {
        var body_ = bodyView.Find("Body");
        if (!body_) return;
        var head_ = body_.Find("Head");
        if (!head_) return;

        head = head_;
    }

    private void UpdateCamera()
    {
        foreach(var screen in screens)
        {
            screen.camera.transform.position = this.transform.position + head.transform.position;
            screen.camera.transform.LookAt(screen.quad.transform.position, Vector3.up);
        }
    }
}
