using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMove : MonoBehaviourPun
{
    [SerializeField]
    private float moveSpeed = 10.0f;

    [SerializeField]
    private float rotationSpeed = 5.0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (!photonView.IsMine) return;
        if (GameManager.Instance.isGameOver) return;
        ProcessInput();
        LookTowardMouse();
    }

    private void ProcessInput() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveToward = new Vector3(-v, 0f, h).normalized;
        transform.Translate(moveToward * moveSpeed * Time.deltaTime, Space.World);
    }

    private void LookTowardMouse() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;
        Vector3 point;

        if (Physics.Raycast(ray, out hitData, 1000, 1<<LayerMask.NameToLayer("Floor"))) {
            point = hitData.point;

            Vector3 targetDirection = point - transform.position;
            float singleStep = rotationSpeed * Time.deltaTime;

            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
