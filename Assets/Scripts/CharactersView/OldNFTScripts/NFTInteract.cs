using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


//Used by metadata class for storing attributes
public class Attributes
{
    //The type or name of a given trait
    public string trait_type;
    //The value associated with the trait_type
    public string value;
}

//Used for storing NFT metadata from standard NFT json files
public class Metadata
{
    //List storing attributes of the NFT
    public List<Attributes> attributes { get; set; }
    //Description of the NFT
    public string description { get; set; }
    //An external_url related to the NFT (often a website)
    public string external_url { get; set; }
    //image stores the NFTs URI for image NFTs
    public string image { get; set; }
    //Name of the NFT
    public string name { get; set; }
}

//Interacting with blockchain
public class NFTInteract : MonoBehaviour
{
    
    //The chain to interact with, using Polygon here
    public string chain = "polygon";
    //The network to interact with (mainnet, testnet)
    public string network = "mainnet";
    //Contract to interact with, contract below is "Project: Pigeon Smart Contract"
    public string contract = "0xb68bCe041c7DDbA9d03AFD13BFeCf9d89aB8ba65";
    //Token ID to pull from contract
    public string tokenId = "0";
    
    /*
    public string chain = "ethereum";
    public string network = "rinkeby";
    public string contract = "0x5D5220AC4aE1615C6ff524490e3b23988190599A";
    //Token ID to pull from contract
    public string tokenId = "0";
    */

    //Used for storing metadata
    Metadata metadata;

    private void Start()
    {
        //Starts async function to get the NFT image
        GetNFTImage();
    }

    async private void GetNFTImage()
    {
        //Interacts with the Blockchain to find the URI related to that specific token
        string URI = await ERC721.URI(chain, network, contract, tokenId);
        Debug.Log(URI);

        //Perform webrequest to get JSON file from URI
        using (UnityWebRequest webRequest = UnityWebRequest.Get(URI))
        {
            //Sends webrequest
            await webRequest.SendWebRequest();
            //Gets text from webrequest
            string metadataString = webRequest.downloadHandler.text;
            //Converts the metadata string to the Metadata object
            metadata = JsonConvert.DeserializeObject<Metadata>(metadataString);
        }

        string imageUri = metadata.image;
        Debug.Log(imageUri);

        //Performs another web request to collect the image related to the NFT
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(imageUri))
        {
            //Sends webrequest
            await webRequest.SendWebRequest();
            //Gets the image from the web request and stores it as a texture
            Texture textureOriginal = DownloadHandlerTexture.GetContent(webRequest);
            Texture2D texture2d = (Texture2D) textureOriginal;
            Sprite mySprite = Sprite.Create(texture2d, new Rect(0.0f, 0.0f, texture2d.width, texture2d.height), new Vector2(0.5f, 0.5f), 100.0f);
            //Sets the objects main render material to the texture
            Debug.Log("Got sprite");

            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = mySprite;
            //this.gameObject.GetComponent<Image>().sprite = mySprite;
            Debug.Log("Updated sprite");
        }
        
    }
}

