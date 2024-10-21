## 說明

- 開啟後置攝影機的方法，同時修正攝影機解析度不正確或者顛倒等問題
- PhysicCamera - 主要的程式碼
  - EnableCamera - 啟動攝影機，同時返回 WebCamTexture
  - DisableCamera - 取消攝影機
  - PauseCamera - 暫停
  - PlayCamera - 播放
  - TryGetWebCamCorrectInfo - 取得 WebCam 調整過後的參數，用來替換 UI 上的數值
