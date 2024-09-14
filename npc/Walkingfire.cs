using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using IL.Terraria.DataStructures;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ModLoader.Utilities;
using WeaponDemo.Items;
using IL.Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.ItemDropRules;
using System.Numerics;
using WeaponDemo.Projectiles;
using Humanizer;
using System.Security.Cryptography.X509Certificates;


namespace WeaponDemo.npc
{
   class Walkingfire : Fsmnpc { 
        private bool _friendly = false;
        private int _FrameTime = 0;
        private bool _dash = false;
        int time;
        public override void SetStaticDefaults()
        {
            base.SetDefaults();
            Terraria.Main.npcFrameCount[NPC.type] = 3;
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            NPC.lifeMax = 1000;
            NPC.defense = 50;
            NPC.damage = 300;
            NPC.width =34;
            NPC.height =75;
            NPC.friendly = false;
            NPC.noGravity = false;
            NPC.noTileCollide = false;
            NPC.knockBackResist = 0.3f;
            AIType = 1;
        }
        public override void AI()
        {
            _FrameTime++;
            time++;
            foreach (var p in Main.player)
            {
                // 寻找最近的一个玩家
                NPC.TargetClosest(false);
                Player target = Main.player[NPC.target];
                Microsoft.Xna.Framework.Vector2 directionToPlayer = target.Center - NPC.Center;//速率
                Microsoft.Xna.Framework.Vector2 DTP = target.Center - NPC.Center;
                // 确保玩家是活跃的
                if (target.active)
                {
                    if(NPC.noTileCollide && NPC.position.Y > (int)NPC.position.Y / 16 * 16)//检测是否有碰撞，用来查看NPC是否在空中
                    {
                        directionToPlayer.X = 0;//空中不允许平移
                    }
                // 计算僵尸到玩家的方向 
                directionToPlayer.Y = 0f; // 只保留水平方向
                    if (directionToPlayer != Microsoft.Xna.Framework.Vector2.Zero)
                    {
                        directionToPlayer.Normalize();
                        if (NPC.velocity.Y == 0f)
                        {
                            NPC.velocity = directionToPlayer * 3f; // 设置移动速度
                        }
                    }
                }
            }
        }
        public override void FindFrame(int frameHeight)
        {
            switch (_FrameTime)
            {
                case 1:
                    {
                        NPC.frame.Y = 0;
                        break;
                    }
                case 2:
                    {
                        NPC.frame.Y = frameHeight;
                        break;
                    }
                case 3:
                    {
                        NPC.frame.Y = frameHeight * 2;
                        _FrameTime = 0;
                        break;
                    }
            }
        }
    }
    public abstract class Fsmnpc : ModNPC
    {
        protected float time1
        {
            get => NPC.ai[2];
            set => NPC.ai[2] = value;

        }
        protected float time2
        {
            get => NPC.ai[3];
            set => NPC.ai[3] = value;

        }
        protected float state1
        {
            get => NPC.ai[0];
            set => NPC.ai[0] = value;

        }
        protected float state2
        {
            get => NPC.ai[1];
            set => NPC.ai[1] = value;

        }
        protected virtual void s1(int num)
        {
            state1 = num;
        }
        protected virtual void s2(int num)
        {
            state2 = num;
        }
    }

}



