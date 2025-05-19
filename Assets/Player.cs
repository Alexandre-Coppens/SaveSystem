using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class PlayerInfo
{
    public List<string> items;
    public int level;
    public string name;
    public float stat1;
    public float stat2;
    public float stat3;
    public float stat4;
}

public class Player : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public Camera cam;
    public Rigidbody rb;
    public GameObject enemyPrefab;

    private Vector2 deltaCam;
    private Vector2 deltaMov;
    public float speed;

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        rb = GetComponentInChildren<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        deltaMov = Vector2.zero;
        deltaCam = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        cam.transform.eulerAngles += new Vector3(-deltaCam.y, deltaCam.x, 0);
        if (Input.GetKey(KeyCode.W)) deltaMov.y += 1;
        if (Input.GetKey(KeyCode.S)) deltaMov.y -= 1;
        if (Input.GetKey(KeyCode.D)) deltaMov.x += 1;
        if (Input.GetKey(KeyCode.A)) deltaMov.x -= 1;
        float y = rb.velocity.y;
        rb.velocity = (Vector3.ProjectOnPlane(cam.transform.forward, Vector3.up) * deltaMov.y + cam.transform.right * deltaMov.x) * speed;
        rb.velocity = new Vector3(rb.velocity.x, y, rb.velocity.z);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500))
            {
                if (hit.collider.tag == "Respawn")
                {
                    hit.collider.GetComponentInParent<Enemies>().Die();
                }
                else
                {
                    Vector3 fwd = (hit.point - transform.position).normalized;
                    GameObject mob = Instantiate(enemyPrefab);
                    mob.transform.position = hit.point;
                    mob.transform.rotation = Quaternion.LookRotation(fwd, Vector3.up);
                }
            }
        }
    }

    public void Load(PlayerInfo newInfo)
    {
        playerInfo = newInfo;
    }
}
