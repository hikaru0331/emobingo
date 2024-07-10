using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine;

namespace PUN2Sample
{
    public static class PlayerPropertiesExtensions
    {
        private const string ScoreKey = "Score";
        private const string RankKey = "Rank";

        private static readonly Hashtable propsToSet = new Hashtable();
        // プレイヤーのランクの配列
        private static readonly string[] ranks = { "A", "B", "C" };

        // プレイヤーのスコアを取得する
        public static int GetScore(this Player player) 
        {
            return (player.CustomProperties[ScoreKey] is int score) ? score : 0;
        }

        // プレイヤーのスコアを加算する
        public static void AddScore(this Player player, int value) 
        {
            propsToSet[ScoreKey] = player.GetScore() + value;
            player.SetCustomProperties(propsToSet);
            propsToSet.Clear();
        }

         // プレイヤーのランクを取得する
        public static string GetRank(this Player player) 
        {
            if (player.CustomProperties[RankKey] is string rank)
            {
                return rank;
            }
            else 
            {
                return ranks[ranks.Length - 1];
            }
        }

        // プレイヤーのランクをランダムに設定する
        public static void SetRandomRank(this Player player) 
        {
            propsToSet[RankKey] = ranks[Random.Range(0, ranks.Length)];
            player.SetCustomProperties(propsToSet);
            propsToSet.Clear();
        }
    }
}