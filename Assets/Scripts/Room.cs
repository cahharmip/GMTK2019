using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour //ประตูห้อง จะเรียงลำดับ 0 - 3 วนตามเข็มนาฬิกาเสมอ
{
  [SerializeField]
  private uint _RoomID;
  [SerializeField]
  private Room[] _AdjacentRoom;
  [SerializeField]
  private Portal[] _Portals;
}
