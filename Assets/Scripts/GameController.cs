using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
  private Vector3 OriginCameraPosition = new Vector3(-0.93f, 25.12f, 1.07f);
  protected void Awake()
  {
    _MainCamera.transform.position = OriginCameraPosition;
    if (SceneManager.GetActiveScene().name == "Stage0")
    {
      Button playButton = _IntroCanvas.transform.Find("Button").GetComponent<Button>();
      playButton.onClick.AddListener(OnPlayButtonClicked);
    }
  }

  protected void Start()
  {
    if (SceneManager.GetActiveScene().name != "Stage0")
    {
      StartCoroutine(DoCloseIntroUI());
    }
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
      if (_IntroCanvas != null) _IntroCanvas.GetComponent<CanvasGroup>().alpha = 1 - (time / Time.deltaTime);
      _MainCamera.transform.position = new Vector3(
        (OriginCameraPosition.x * (1 - fraction)) + PlayCameraPosition.x * fraction,
        (OriginCameraPosition.y * (1 - fraction)) + PlayCameraPosition.y * fraction,
        (OriginCameraPosition.z * (1 - fraction)) + PlayCameraPosition.z * fraction);
      yield return null;
    }
    if (_IntroCanvas != null) _IntroCanvas.GetComponent<CanvasGroup>().alpha = 0;
    _MainCamera.transform.position = new Vector3(PlayCameraPosition.x, PlayCameraPosition.y, PlayCameraPosition.z);
  }

  public void DoRestart()
  {
    GameObject obj = Instantiate(ResourceLoadManager.LoadGameObject("Prefabs/CanvasRestart"));
    obj.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().name); });
  }

  private IEnumerator DoIntroStage()
  {
    yield return null;
  }
}
