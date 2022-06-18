using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private int _hitPoints = 1;
    [SerializeField] private int _scorePoints = 100;
    [SerializeField] private Vector3 rotator;
    public Material hitMaterial;
    Material _orgMaterial;
    Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(rotator * (transform.position.x + transform.position.y ) * 0.1f);
        renderer = GetComponent<Renderer>();
        _orgMaterial = renderer.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotator * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _hitPoints--;
        

        if (_hitPoints <= 0)
        {
            GameManager.Instance.Score += _scorePoints;
            Destroy(gameObject);
        }
        renderer.sharedMaterial = hitMaterial;
        Invoke("RestoreOrgMaterial", 0.5f);
    }

    void RestoreOrgMaterial()
    {
        renderer.sharedMaterial = _orgMaterial;
    }
}
