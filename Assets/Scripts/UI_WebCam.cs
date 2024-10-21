using UnityEngine;
using UnityEngine.UI;

public class UI_WebCam : MonoBehaviour
{
	[SerializeField] private RawImage          webCamImg;
	[SerializeField] private AspectRatioFitter webCamAspectRatioFitter;

	private readonly PhysicCamera physicCamera = new();

	private void Update()
	{
		if (!physicCamera.TryGetWebCamCorrectInfo(out var info))
			return;

		webCamAspectRatioFitter.aspectRatio      = info.aspect;
		webCamImg.rectTransform.localEulerAngles = new Vector3(0, 0, info.rotation);
		webCamImg.rectTransform.localScale       = new Vector3(1, info.scale, 1);
	}

	public void Button_Enable()
	{
		webCamImg.texture = physicCamera.EnableCamera();
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