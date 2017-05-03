using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{

	private Rigidbody2D _rb2D;
    private int _points;

    [SerializeField]
	private float acceleration=10f;
    [SerializeField]
    private Text lblPoints;
    [SerializeField]
    private Text lblYouWin;


    // Use this for initialization
    void Start () 
	{
		_rb2D = gameObject.GetComponent<Rigidbody2D>();
        _points = 0;
        //Debug.Assert(lblPoints != null);
        lblPoints.text = "Punteggio: " + _points;
        lblYouWin.gameObject.SetActive(false);
	}

	void FixedUpdate()
	{
		float moveVertical = Input.GetAxis ("Vertical"); //(-1;+1)
		float moveHorizontal = Input.GetAxis("Horizontal");
		_rb2D.AddForce(new Vector2 (moveHorizontal,moveVertical)*acceleration);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        switch (other.tag)
        {
            case "PickUp":
                other.gameObject.SetActive(false);
                addPoints(1);

                if(isWinning())
                {
                    lblYouWin.gameObject.SetActive(true);
                }
                break;
            case "Enemy":
                lblYouWin.text = "You Lose";
                lblYouWin.gameObject.SetActive(true);
                break;
        }
    }

    void addPoints(int points)
    {
        _points+=points;
        lblPoints.text = "Punteggio: " + _points;
    }

    bool isWinning()
    {
        return (_points >= 12);
    }
}
