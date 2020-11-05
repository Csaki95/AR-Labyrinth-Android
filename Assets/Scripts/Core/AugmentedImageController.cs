using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using UnityEngine.UI;
using GoogleARCore.Examples.AugmentedImage;


public class AugmentedImageController : MonoBehaviour
{
    // Text output for debuging
    public Text outPut;

    // Public tracking state for communication with GameManager
    public bool imageTrackingState;

    // Reference for Target Gameobject Position
    public Vector3 targetPosition;
    public Quaternion targetRotation;

    // List of Augmented target images
    private List<AugmentedImage> _tempAugmentedImages = new List<AugmentedImage>();

    private void Awake()
    {
        //GameObject.Find("ARCore Device").GetComponent<ARCoreSession>().enabled = true;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Session.Status != SessionStatus.Tracking )
        {
            outPut.text = "Session doesn't Start";
        }

        // Get updated augmented images for this frame.
        Session.GetTrackables<AugmentedImage>(
            _tempAugmentedImages, TrackableQueryFilter.Updated);

        // Create visualizers and anchors for updated augmented images that are tracking and do
        // not previously have a visualizer. Remove visualizers for stopped images.
        foreach (var image in _tempAugmentedImages)
        {
            // Image found
            if (image.TrackingState == TrackingState.Tracking)
            {
                // Create an anchor to ensure that ARCore keeps tracking this augmented image.
                Anchor anchor = image.CreateAnchor(image.CenterPose);
                targetPosition = anchor.transform.position;
                targetRotation = anchor.transform.rotation;
                imageTrackingState = true;
                outPut.text = "Tracking";
            }
            // Image tracking stopped
            else if (image.TrackingState == TrackingState.Stopped)
            {
                imageTrackingState = false;
                outPut.text = "Stopped";
            } 
            // Image tracking Paused, so the tracking is still active, but no target found
            else if (image.TrackingState == TrackingState.Paused)
            {
                imageTrackingState = false;
                outPut.text = "Paused";
            }

            // Turn off Tracking for Images that are not in frame anymore
            switch (image.TrackingMethod)
            {
                case AugmentedImageTrackingMethod.FullTracking:
                    //visualizer.gameObject.SetActive(true);
                    imageTrackingState = true;
                    outPut.text = "Tracking in progress ...";
                    break;
                case AugmentedImageTrackingMethod.LastKnownPose:
                    //visualizer.gameObject.SetActive(false);
                    imageTrackingState = false;
                    outPut.text = "LastKnownPose";
                    break;
                case AugmentedImageTrackingMethod.NotTracking:
                    //visualizer.gameObject.SetActive(false);
                    imageTrackingState = false;
                    outPut.text = "Not Tracking";
                    break;
            }
        }
    }

}
