using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;


public class AugmentedImageController : MonoBehaviour
{
    // Public tracking state for communication with GameManager
    [Header("Is tracking active:")]
    [System.NonSerialized]
    public bool imageTrackingState;

    // Readonly Target Gameobject Position
    [Header("Position, and Rotation of target image")]
    [System.NonSerialized]
    public Vector3 targetPosition;
    [System.NonSerialized]
    public Quaternion targetRotation;

    // List of Augmented target images
    private readonly List<AugmentedImage> _tempAugmentedImages = new List<AugmentedImage>();

    public void Update()
    {
        // Get updated augmented images for this frame.
        Session.GetTrackables<AugmentedImage>(
            _tempAugmentedImages, TrackableQueryFilter.Updated);

        // Create an anchor for updated augmented images that are tracking
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
            }
            // Image tracking stopped
            else if (image.TrackingState == TrackingState.Stopped)
            {
                imageTrackingState = false;
            } 
            // Image tracking Paused, so the tracking is still active, but no target found
            else if (image.TrackingState == TrackingState.Paused)
            {
                imageTrackingState = false;
            }

            // Tracking status for current ARSession
            switch (image.TrackingMethod)
            {
                case AugmentedImageTrackingMethod.FullTracking:
                    imageTrackingState = true;
                    break;
                case AugmentedImageTrackingMethod.LastKnownPose:
                    imageTrackingState = false;
                    break;
                case AugmentedImageTrackingMethod.NotTracking:
                    imageTrackingState = false;
                    break;
            }
        }
    }

}
