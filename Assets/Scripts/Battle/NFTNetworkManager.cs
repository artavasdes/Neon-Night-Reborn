using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mirror;

struct CreateCharacterMessage : NetworkMessage
{
    public int characterId;
}

public struct DamageCharacterMessage : NetworkMessage
{
    public bool isCharHosting;
    public int damage;
}


public class NFTNetworkManager : NetworkManager
{
    public override void OnStartServer()
    {
        base.OnStartServer();

        NetworkServer.RegisterHandler<CreateCharacterMessage>(OnCreateCharacter);
        NetworkServer.RegisterHandler<DamageCharacterMessage>(OnDamageCharacter);
    }

    void OnDamageCharacter(NetworkConnectionToClient conn, DamageCharacterMessage message) {
      if (GlobalNetState.isHosting == message.isCharHosting) {
        Character_Control player = NetworkClient.localPlayer.GetComponent<Character_Control>();
        player.TakeDamage(message.damage);
      }
    }

    void OnCreateCharacter(NetworkConnectionToClient conn, CreateCharacterMessage message)
    {
        // playerPrefab is the one assigned in the inspector in Network
        // Manager but you can use different prefabs per race for example
        GameObject gameobject = Instantiate(playerPrefab);

        // Apply data from the message however appropriate for your game
        // Typically Player would be a component you write with syncvars or properties
        Character_Control player = gameobject.GetComponent<Character_Control>();
        player.SetCharacterId(message.characterId);

        player.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
        // call this to use this gameobject as the primary controller
        NetworkServer.AddPlayerForConnection(conn, gameobject);
    }
}
