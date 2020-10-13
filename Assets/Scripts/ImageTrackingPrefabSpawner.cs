using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using TMPro;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTrackingPrefabSpawner: MonoBehaviour
{

    [SerializeField]
    public GameObject mapPrefab;

    [SerializeField]
    public TMP_Text statusComponent;

    private ARTrackedImageManager trackedImageManager;

    private void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        GameObject newPrefab = Instantiate(mapPrefab, Vector3.zero, Quaternion.identity);
        newPrefab.name = mapPrefab.name;
        newPrefab.SetActive(false);
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach(ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateImage(trackedImage);
            statusComponent.text = "New image added";
        }
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateImage(trackedImage);
            statusComponent.text = "Image updated";
        }
        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            mapPrefab.SetActive(false);
            statusComponent.text = "Image removed";
        }
    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;
        Vector3 position = trackedImage.transform.position;

        mapPrefab.transform.position = position;
        mapPrefab.SetActive(true);
    }
}
