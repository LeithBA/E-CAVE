using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveScreen
{
    public GameObject quad, camera;

    public CaveScreen(Transform parent, int ID)
    {
        parent.name = "CaveScreen_" + ID;
        quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        quad.name = "Quad";
        quad.transform.parent = parent;
        quad.transform.localPosition = Vector3.zero;
        quad.transform.localRotation = Quaternion.identity;
        quad.transform.localScale = Vector3.one;

        camera = new GameObject("Camera");
        camera.transform.parent = parent;
        camera.transform.localPosition = Vector3.zero;
        camera.transform.localRotation = Quaternion.identity;
        camera.transform.localScale = Vector3.one;

        var cam = camera.AddComponent<Camera>();
        cam.targetDisplay = ID - 1;
        cam.cullingMask = ~(1 << 9);
        cam.aspect = parent.localScale.x / parent.localScale.y;
        
        var projMat = camera.AddComponent<ProjMatrix>();
        projMat.projectionScreen = quad;
    }

}
