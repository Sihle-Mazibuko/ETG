using UnityEngine;

#region Class Description:
/*
 * 
 */
#endregion

public class OpenURL : MonoBehaviour
{
    #region Fields

    // site
    public string websiteAddress;
    #endregion

    #region Open URL

    public void OpenURLOnClick()
    {
        // open URL
        Application.OpenURL(websiteAddress);
    }
    #endregion
}
