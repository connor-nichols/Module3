using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI totalGemsText;
    public TextMeshProUGUI winText;

    public GameObject winObject;
    public GameObject playerObject;

    private int count;

    [SerializeField]
    private AudioClip collectChime;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;

        SetCountText();
        winText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(playerObject.transform.position, winObject.transform.position);
        distanceText.SetText("Distance to End: " + distance);
        if (count == 25 && distance <= 2)
        {
            winText.text = "You win!";
            winText.enabled = true;
        }
        else if (distance <= 2)
        {
            winText.text = "You found the hidden treasure! Collect all gems to win!";
            winText.enabled = true;
        }
        else if (count == 25)
        {
            winText.text = "You found all gems! Find the treasure chest to win!";
            winText.enabled = true;
        }
        else
        {
            winText.enabled = false;
        }
    }

    void SetCountText()
    {
        totalGemsText.text = "Gems Collected: " + count.ToString();
        if (count >= 25)
        {
            winText.text = "Congrats! You found all gems!";
            winText.enabled = true;
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
