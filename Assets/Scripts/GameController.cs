using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
  [SerializeField]
  private float _IntroUIFadeTime = 1;
  [SerializeField]
  private float _DoIntroStageTime = 4;
  [SerializeField]
  private Canvas _IntroCanvas;
  [SerializeField]
  private Camera _MainCamera;

  private Vector3 PlayCameraPosition = new Vector3(8.46f, 11.85f, -8.32f);
  private Vector3 OriginCameraPosition;
  protected void Awake()
  {
    OriginCameraPosition = _MainCamera.transform.position;
    Button playButton = _IntroCanvas.transform.Find("Button").GetComponent<Button>();
    playButton.onClick.AddListener(OnPlayButtonClicked);
  }

  private void OnPlayButtonClicked()
  {
    _IntroCanvas.GetComponent<CanvasGroup>().interactable = false;
    StartCoroutine(DoCloseIntroUI());
  }

  private IEnumerator DoCloseIntroUI()
  {
    float time = 0;
    while (time < _IntroUIFadeTime)
    {
      time += Time.deltaTime;
      float fraction = 1 - Mathf.Pow(2, -(10 * (time/_IntroUIFadeTime)));
      _IntroCanvas.GetComponent<CanvasGroup>().alpha = 1 - (time / Time.deltaTime);
      _MainCamera.transform.position = new Vector3(
        (OriginCameraPosition.x * (1 - fraction)) + PlayCameraPosition.x * fraction,
        (OriginCameraPosition.y * (1 - fraction)) + PlayCameraPosition.y * fraction,
        (OriginCameraPosition.z * (1 - fraction)) + PlayCameraPosition.z * fraction);
      yield return null;
    }
    _IntroCanvas.GetComponent<CanvasGroup>().alpha = 0;
    _MainCamera.transform.position = new Vector3(PlayCameraPosition.x, PlayCameraPosition.y, PlayCameraPosition.z);
  }

  private IEnumerator DoIntroStage()
  {
    yield return null;
  }
}
