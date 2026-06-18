using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDataClass
{
    // Player respawn
    [SerializeField] private Vector3 m_respawnPos;
    public Vector3 RespawnPos { get { return m_respawnPos; } set { m_respawnPos = value; } }

    // Player movement
    [SerializeField] private float m_walkSpeed = 5f;
    public float walkSpeed { get { return m_walkSpeed; } }
    [SerializeField] private float m_sprintSpeed = 10f;
    public float sprintSpeed { get { return m_sprintSpeed; } }
}

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private PlayerDataClass m_DataClass;
    public PlayerDataClass DataClass { get { return m_DataClass; } }
}
