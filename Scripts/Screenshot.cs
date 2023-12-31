using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Screenshot : MonoBehaviour
{
    public void ClickScreenshot()
    {
        StartCoroutine(TakeScreenshotAndSave());
    }

    private IEnumerator TakeScreenshotAndSave()
    {
	yield return new WaitForEndOfFrame();

	Texture2D ss = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );
	ss.ReadPixels( new Rect( 0, 0, Screen.width, Screen.height ), 0, 0 );
	ss.Apply();

	NativeGallery.Permission permission = NativeGallery.SaveImageToGallery( ss, "GalleryTest", "Image.png", ( success, path ) => Debug.Log( "Media save result: " + success + " " + path ) );

	Debug.Log( "Permission result: " + permission );

	Destroy( ss );
    }
}
