using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Kinect = Windows.Kinect;


public class POV : IComparable<POV>
{
    public GameObject screen, camera;

    public POV(GameObject newScreen, GameObject newCamera)
    {
        screen = newScreen;
        camera = newCamera;
    }

    //This method is required by the IComparable
    //interface. 
    public int CompareTo(POV other)
    {
        if (other == null)
        {
            return 1;
        }

        //Return the difference in power.
        return power - other.power;
    }
}

public class CaveManager : MonoBehaviour
{
    public GameObject cameraPrefab, screenContainer;
    private Transform head, bodyView;
    private List<GameObject> screens = new List<GameObject>();
    private List<GameObject> cameras =



    private void Awake()
    {
        foreach (Transform screen in screenContainer.transform)
        {
            screens.Add(screen.gameObject);

        }


        cam = Instantiate(cameraPrefab, this.transform).GetComponent<Camera>();
        cam.GetComponent<ProjMatrix>().projectionScreen = screen.gameObject;
        cam.transform.parent = this.transform;
        cam.cullingMask = ~(1 << 9);
        cam.aspect = screenResolution.x / screenResolution.y;

        bodyView = this.transform.Find("BodyView");


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
        //UpdateCameraFOV();
        UpdateCameraPosition();
        UpdateCameraRotation();
    }

    private void UpdateCameraPosition()
    {
        cam.transform.position = head.transform.position;
    }

    private void UpdateCameraRotation()
    {
        cam.transform.LookAt(screen, Vector3.up);
    }
}
