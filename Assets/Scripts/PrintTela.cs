using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class PrintTela : MonoBehaviour
{
     void Update()
    {
       
    }


    public void PrintDaTela()
    {
        String caminhoDocumento = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        String caminhoCompleto = Path.Combine(caminhoDocumento, Application.productName);

        DirectoryInfo pastaScreensshot = Directory.CreateDirectory(caminhoCompleto);

        ScreenCapture.CaptureScreenshot(Path.Combine(pastaScreensshot.FullName, "print-" + DateTime.Now.Ticks + "png"));
    }

}
