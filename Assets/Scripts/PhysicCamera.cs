using UnityEngine;

public class PhysicCamera
{
	public WebCamTexture WebCamTexture { get; private set; }

	/// <summary>
	/// 啟用相機
	/// </summary>
	public WebCamTexture EnableCamera()
	{
		var devices = WebCamTexture.devices;

		foreach (var device in devices)
		{
			if (device.isFrontFacing)
				continue;

			WebCamTexture = new WebCamTexture(device.name, Screen.width, Screen.height);

			break;
		}

		if (WebCamTexture == null)
		{
			Debug.LogError("沒有找到後置相機");

			return null;
		}

		WebCamTexture.Play();

		return WebCamTexture;
	}

	/// <summary>
	/// 暫停相機
	/// </summary>
	public void PauseCamera()
	{
		if (WebCamTexture == null)
			return;

		WebCamTexture.Pause();
	}

	/// <summary>
	/// 停用相機，並清除 WebCamTexture Cache
	/// </summary>
	public void DisableCamera()
	{
		if (WebCamTexture == null)
			return;

		WebCamTexture.Stop();
		WebCamTexture = null;
	}

	/// <summary>
	/// 播放相機
	/// </summary>
	public void PlayCamera()
	{
		if (WebCamTexture == null)
			return;

		WebCamTexture.Play();
	}

	public bool TryGetWebCamCorrectInfo(out WebCamCorrectInfo info)
	{
		if (WebCamTexture == null)
		{
			info = default;

			return false;
		}

		info.aspect   = (float)WebCamTexture.width / WebCamTexture.height;
		info.rotation = WebCamTexture.videoRotationAngle;
		info.scale    = WebCamTexture.videoVerticallyMirrored ? -1 : 1;

		return true;
	}

	public struct WebCamCorrectInfo
	{
		public float aspect;
		public int   rotation;
		public float scale;
	}
}