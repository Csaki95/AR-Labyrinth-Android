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

    Anchor anchor;

    public void Update()
    {
        // Get updated augmented images for this frame.
        Session.GetTrackables<AugmentedImage>(
            _tempAugmentedImages, TrackableQueryFilter.Updated);

        // Create an anchor for updated augmented images that are tracking
        foreach (var image in _tempAugmentedImages)
        {
            // Image found
            if (image.TrackingMethod == AugmentedImageTrackingMethod.FullTracking)
            {
                // Create an anchor to ensure that ARCore keeps tracking this augmented image.
                anchor = image.CreateAnchor(image.CenterPose);
                targetPosition = anchor.transform.position;
                targetRotation = anchor.transform.rotation;
                imageTrackingState = true;
            }
            // Image tracking stopped, or not accurate enough
            else if (image.TrackingMethod == AugmentedImageTrackingMethod.LastKnownPose ||
                     image.TrackingMethod == AugmentedImageTrackingMethod.NotTracking)
            {
                imageTrackingState = false;
            }
        }
    }

}
