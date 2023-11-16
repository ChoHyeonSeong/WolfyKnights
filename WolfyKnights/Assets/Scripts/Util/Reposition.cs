using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    private Collider2D _coll;
    private Vector3 _playerDir;

    private void Awake()
    {
        _coll = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        PlayerJoystick.OnInput += UpdatePlayerDir;
    }

    private void OnDisable()
    {
        PlayerJoystick.OnInput -= UpdatePlayerDir;
    }

    private void UpdatePlayerDir(Vector2 input)
    {
        _playerDir = input;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.Instance.Player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        float dirX = _playerDir.x < 0 ? -1 : 1;
        float dirY = _playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                else
                {
                    transform.Translate(dirX * 40, dirY * 40, 0);
                }
                break;
            case "Enemy":
                if (_coll.enabled)
                {
                    transform.Translate(_playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f)));
                }
                break;
        }
    }
}
