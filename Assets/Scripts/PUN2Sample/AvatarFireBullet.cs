using Photon.Pun;
using UnityEngine;

namespace PUN2Sample
{
    public class AvatarFireBullet : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private Bullet bulletPrefab = default;

        private int nextBulletId = 0;

        private void Update() {
            if (photonView.IsMine) {
                // 左クリックでカーソルの方向に弾を発射する
                if (Input.GetMouseButtonDown(0)) {
                    var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    var direction = mousePosition - transform.position;
                    float angle = Mathf.Atan2(direction.y, direction.x);
                    
                    // 弾を発射するたびに弾のIDを1ずつ増やしていく
                    photonView.RPC(nameof(FireBullet), RpcTarget.All, nextBulletId++, angle);
                }
            }
        }

        // 弾を発射するメソッド
        [PunRPC]
        private void FireBullet(int id, float angle, PhotonMessageInfo info)
        {
            var bullet = Instantiate(bulletPrefab);
            // 弾を発射した時刻に50msのディレイをかける
            int timestamp = unchecked(info.SentServerTimestamp + 50);
            bullet.Init(id, photonView.OwnerActorNr, transform.position, angle, timestamp);
        }
    }
}