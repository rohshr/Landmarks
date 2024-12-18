using UnityEngine;
using Valve.VR;

public class ControllerOrientationFix : MonoBehaviour
{
    public SteamVR_Input_Sources handType; // Select LeftHand or RightHand in the Inspector
    public Vector3 rotationOffset = new Vector3(90f, 0f, 0f); // Offset to correct the upside-down rotation

    void Update()
    {
        // Fetch the SteamVR Pose action for position and rotation
        var pose = SteamVR_Input.GetAction<SteamVR_Action_Pose>("Pose");

        if (pose != null)
        {
            // Apply SteamVR's tracking position and rotation
            transform.localPosition = pose.GetLocalPosition(handType);
            transform.localRotation = pose.GetLocalRotation(handType);

            // Apply additional rotation offset to correct orientation
            transform.Rotate(rotationOffset, Space.Self);
        }
    }

    void LateUpdate()
    {
        // Apply position and rotation
        var pose = SteamVR_Actions.default_Pose;
        if (pose != null)
        {
            transform.localPosition = pose.GetLocalPosition(handType);
            transform.localRotation = pose.GetLocalRotation(handType);

            // Apply offset
            transform.Rotate(rotationOffset, Space.Self);
        }
    }
}
