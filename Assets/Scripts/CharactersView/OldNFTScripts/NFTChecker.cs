using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using System.Numerics;

public class NFTChecker : MonoBehaviour
{
    public string chain = "ethereum";
    public string network = "rinkeby";
    public string contract = "0x5D5220AC4aE1615C6ff524490e3b23988190599A";
    public string account = "0x36F4D7ff8C442ea1eB38F60BeC8e8177101134BC";
    public string tokenId = "10";
    private void Start(){
        GetNFTImage();
    }

    public class Response {
        public string image;
    }

    async private void GetNFTImage(){
        string uri = await ERC1155.URI(chain, network, contract, tokenId);
        Debug.Log(uri);

        UnityWebRequest webRequest = UnityWebRequest.Get(uri);
        await webRequest.SendWebRequest();
        Response data = JsonUtility.FromJson<Response>(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));

        string imageUri = data.image;
        Debug.Log(imageUri);

        using (UnityWebRequest textureRequest = UnityWebRequestTexture.GetTexture(imageUri))
        {
            await textureRequest.SendWebRequest();
            //Texture2D texture2d = DownloadHandlerTexture.GetContent(textureRequest);
            Texture2D texture2d = ((DownloadHandlerTexture)textureRequest.downloadHandler).texture;
            if(texture2d == null){
                Debug.Log("texture2d null");
            }
            BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, account, tokenId);
            Debug.Log(balanceOf);

            // Sprite mySprite = Sprite.Create(texture2d, new Rect(0.0f, 0.0f, texture2d.width, texture2d.height), new Vector2(0.5f, 0.5f), 100.0f);
        
            // SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            // spriteRenderer.sprite = mySprite;
        }
    }
}
