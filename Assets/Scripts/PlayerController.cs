using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI totalGemsText;

    public GameObject winObject;
    public GameObject playerObject;
    public GameObject winTextObject;

    private int count;

    [SerializeField]
    private AudioClip collectChime;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(playerObject.transform.position, winObject.transform.position);
        distanceText.SetText("Distance to End: " + distance); 
    }

    void SetCountText()
    {
        totalGemsText.text = "Gems Collected: " + count.ToString();
        if (count >= 25)
        {
            winTextObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            other.gameObject.SetActive(false);
            count++;
            AudioSource.PlayClipAtPoint(collectChime, transform.position);

            SetCountText();
        }

        if (other.gameObject.CompareTag("Skeleton"))
        {
            transform.position = new Vector3(0f, 0.75f, 0f);
        }
    }
}
