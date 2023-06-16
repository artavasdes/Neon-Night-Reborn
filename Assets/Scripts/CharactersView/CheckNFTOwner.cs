using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using System.Threading.Tasks;

public static class CheckNFTOwner
{
    public static string chain = "polygon";
    public static string network = "mainnet";
    public static string contract = "0x3a686FaBCE1b315950D39367131C4C17B1BaBF23";
    public static int tokenIdAmount = 12;
    public static Dictionary<int, bool> ownerDic = new Dictionary<int, bool>();
    public static bool validAddress = false;

    public static async Task CheckOwner(string account)
    {
        for(int i = 0; i <= tokenIdAmount; i++){
            BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, account, i.ToString());
            if(balanceOf == 1){
                ownerDic.Add(i,true);
            }
            else{
                ownerDic.Add(i, false);
            }            
        }    
        await Task.Yield();
    }
}
