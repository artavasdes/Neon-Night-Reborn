using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class ImportNFTTextureExample : MonoBehaviour
{
    public class Response {
        public string image;
    }
    private void Start()
    {
        //Starts async function to get the NFT image
        GetNFTImage();
    }

    async private void GetNFTImage()
    {
        string chain = "ethereum";
        string network = "rinkeby";
        string contract = "0x3a8A85A6122C92581f590444449Ca9e66D8e8F35";
        string tokenId = "5";

        // fetch uri from chain
        string uri = await ERC1155.URI(chain, network, contract, tokenId);
        print("uri: " + uri);

        // fetch json from uri
        UnityWebRequest webRequest = UnityWebRequest.Get(uri);
        await webRequest.SendWebRequest();
        Response data = JsonUtility.FromJson<Response>(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));

        // parse json to get image uri
        string imageUri = data.image;
        print("imageUri: " + imageUri);

        // fetch image and display in game
        UnityWebRequest textureRequest = UnityWebRequestTexture.GetTexture(imageUri);
        await textureRequest.SendWebRequest();

        Texture textureOriginal = ((DownloadHandlerTexture)textureRequest.downloadHandler).texture;
        Texture2D texture2d = (Texture2D) textureOriginal;
        Sprite mySprite = Sprite.Create(texture2d, new Rect(0.0f, 0.0f, texture2d.width, texture2d.height), new Vector2(0.5f, 0.5f), 100.0f);
        Debug.Log("Got sprite");

        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = mySprite;
        Debug.Log("Updated sprite");

        //this.gameObject.GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)textureRequest.downloadHandler).texture;
    }
}
