using System.Collections;
using UnityEngine;
using GoogleARCore;
using TMPro;

public class CompatibiltyCheck : MonoBehaviour
{
    public TMP_Text outputPort;
    public TMP_Text outputLand;
    public TMP_Text loading;
    public GameObject errorScreen;
    public GameObject loadingScreen;

    private ApkAvailabilityStatus status;
    private string errorMessage = null;
    private SceneChange sceneChange;

    private void Start()
    {
        StartCoroutine(CheckAvailability());
        StartCoroutine(LoadingTimeOut());
        sceneChange = gameObject.GetComponent<SceneChange>();
    }

    private void Update()
    {
        if(!(errorMessage is null))
        {
            errorScreen.SetActive(true);
            outputPort.SetText(errorMessage);
            outputLand.SetText(errorMessage);
            loadingScreen.SetActive(false);
        }
    }

    private IEnumerator CheckAvailability()
    {
        AsyncTask<ApkAvailabilityStatus> statusTask = Session.CheckApkAvailability();
        CustomYieldInstruction customYield = statusTask.WaitForCompletion();
        yield return customYield;
        // offset by 2 second just in case getting the status is too fast
        yield return new WaitForSeconds(2);

        status = statusTask.Result;
        switch (status)
        {
            case ApkAvailabilityStatus.SupportedInstalled:
                sceneChange.SceneLoader(1);
                break;
            case ApkAvailabilityStatus.SupportedApkTooOld:
                errorMessage = "  ARCore is supported but the apk is too old. Please update Google Play Services for AR and relaunch the application.";
                break;
            case ApkAvailabilityStatus.SupportedNotInstalled:
                errorMessage = "  ARCore is supported but not installed. Please install Google Play Services for AR from the Play Store and relaunch the application.";
                break;
            case ApkAvailabilityStatus.UnsupportedDeviceNotCapable:
                errorMessage = "  ARCore is not supported on this device. Please use a device that is offically supported by Google. The device is supported if Google Play Services for AR is available in the Play Store.";
                break;
            case ApkAvailabilityStatus.UnknownError:
                errorMessage = "  The ARCore compatibility check has ran into an unexpected Error. You may run into this issue if your device has a modified OS "
                    + "if that's not the case and it supports Google Play Services for AR please post an issue on my Github page and I will get back to you asap.";
                break;
            case ApkAvailabilityStatus.UnknownTimedOut:
                errorMessage = "  The ARCore compatibility check has been timed out. Please make sure Google Play Services for AR is installed and updated on your device and restart the application. "
                    + "if the problem persists please post an issue on my Github page and I will get back to you.";
                break;
        }
    }

    private IEnumerator LoadingTimeOut()
    {
        yield return new WaitForSecondsRealtime(20);
        loading.SetText("Loading may have ran into an issue\n Please restart the application and try again");
    }
}
