using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SSandShare : MonoBehaviour
{
    public void ClickShare()
    {
        StartCoroutine(TakeScreenshotAndShare());
    }

    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );
        ss.ReadPixels( new Rect( 0, 0, Screen.width, Screen.height ), 0, 0 );
        ss.Apply();

        string filePath = Path.Combine( Application.temporaryCachePath, "shared img.png" );
        File.WriteAllBytes( filePath, ss.EncodeToPNG() );

        Destroy( ss );

        new NativeShare().AddFile( filePath )
            .SetSubject( "Subject goes here" ).SetText( "Aruvana Intership Test" ).SetUrl( "https://github.com/ElganMaynard/Test" )
            .SetCallback( ( result, shareTarget ) => Debug.Log( "Share result: " + result + ", selected app: " + shareTarget ) )
            .Share();
    }
}
