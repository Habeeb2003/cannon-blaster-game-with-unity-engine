using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Camera))]
public class RenderParticlesEffect : MonoBehaviour
{

    [SerializeField] private Camera particlesCamera;
    [SerializeField] private Vector2Int imageResolution = new Vector2Int(256, 256);
    public RawImage targetImage;
    [SerializeField] private Image Img;
    public RenderTexture renderTexture;

    private void Awake()
    {
        if (!particlesCamera) particlesCamera = GetComponent<Camera>();
        renderTexture = new RenderTexture(imageResolution.x, imageResolution.y, 32);
        renderTexture.name = "newTexture";
        particlesCamera.targetTexture = renderTexture;
        
        //targetImage.texture = renderTexture;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
