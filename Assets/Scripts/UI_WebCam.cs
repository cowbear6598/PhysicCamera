using UnityEngine;
using UnityEngine.UI;

public class UI_WebCam : MonoBehaviour
{
	[SerializeField] private RawImage          webCamImg;
	[SerializeField] private AspectRatioFitter webCamAspectRatioFitter;

	private readonly PhysicCamera physicCamera = new();

	private void Update()
	{
		if (webCamImg.texture == null)
			return;

		var correctInfo = physicCamera.GetWebCamCorrectInfo();

		webCamAspectRatioFitter.aspectRatio      = correctInfo.aspect;
		webCamImg.rectTransform.localEulerAngles = new Vector3(0, 0, correctInfo.rotation);
		webCamImg.rectTransform.localScale       = new Vector3(1, correctInfo.scale, 1);
	}

	public void Button_Enable()
	{
		physicCamera.EnableCamera();

		webCamImg.texture = physicCamera.GetWebCamTexture();
	}

	public void Button_Disable()
	{
		physicCamera.DisableCamera();
	}

	public void Button_Pause()
	{
		physicCamera.PauseCamera();
	}
}