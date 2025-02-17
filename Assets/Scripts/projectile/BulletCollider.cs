using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BulletCollider : MonoBehaviour
{
    [SerializeField] private GameObject _spriteHit;
    [SerializeField] private int _maxNumberOfPoints;


    private GunCollider _gunCollider;
    private TextMeshProUGUI _textTarget;

    private void Start()
    {
        _textTarget = GameObject.Find("Canvas/NumberOfPoint").GetComponent<TextMeshProUGUI>();
        _gunCollider = GameObject.Find("Character/Gan Collider").GetComponent<GunCollider>();
    }
    public void Sleep(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void FillAmountImage(int countXp, TextMeshProUGUI text, Collision collision)
    {
        _gunCollider._summTarget += countXp;
        text.text = ($"Заработанные очки: {_gunCollider._summTarget}/ {_maxNumberOfPoints}").ToString();
        CreatAndDelete(collision);
        if (_gunCollider._summTarget >= _maxNumberOfPoints)
        {
            if (SceneManager.GetActiveScene().buildIndex == 4) SceneManager.LoadScene(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Winer");

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.gameObject.GetComponent<Index>()) return;

        for (int i = 0; i < 3; i++)
        {
            if (collision.gameObject.GetComponent<Index>()._index == i + 1)
            {
                Debug.Log(i + 1);
                FillAmountImage((i + 1), _textTarget, collision);
            }
        }
    }
    private void CreatAndDelete(Collision collision)
    {
        GameObject obj = Instantiate(_spriteHit);
        obj.transform.eulerAngles = collision.transform.eulerAngles;
        obj.transform.position = collision.contacts[0].point - new Vector3(0, 0, 0.3f);
        Destroy(gameObject);
    }
}
