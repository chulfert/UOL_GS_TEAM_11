using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionControls : MonoBehaviour
{
    public RawImage instructionRawImage;
    public Texture[] instructionTextures; // Array for images
    private int currentIndex = 0;

    private void Start()
    {
        ShowImage(currentIndex);
    }

    //Show next image
    public void ShowNext()
    {
        currentIndex = (currentIndex + 1) % instructionTextures.Length;
        ShowImage(currentIndex);
    }

    //Show previous image
    public void ShowPrevious()
    {
        currentIndex = (currentIndex - 1 + instructionTextures.Length) % instructionTextures.Length;
        ShowImage(currentIndex);
    }

    //Show current image
    private void ShowImage(int index)
    {
        if (index >= 0 && index < instructionTextures.Length)
        {
            instructionRawImage.texture = instructionTextures[index];
        }
    }
}

