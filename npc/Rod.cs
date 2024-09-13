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

namespace weapondemo.npc //NPC
{
    class Rod : Fsmnpc
    {
        private bool _friendly = false;
        public override void SetStaticDefaults()
        {
            base.SetDefaults();
            DisplayName.SetDefault("Rod");
            
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            NPC.lifeMax = 1000;
            NPC.defense = 50;
            NPC.damage = 300;
            NPC.width = 100;
            NPC.height = 100;
            NPC.aiStyle = 1;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0.3f;
        }
        public override void AI()
        {
            foreach (var p in Main.player)
            {
                float max = 100;//敌对距离
                float toplayer = Vector2.Distance(p.Center, NPC.Center);//计算距离 
                if (toplayer < max)
                {
                    _friendly = false;
                }
                else if (toplayer > max)
                {
                    _friendly = true;
                }
            }
            if (_friendly = false)
            {
                NPC.velocity.Y = 0.2f;
            }
            else if (_friendly = true)
            {
                Player player = Main.player[NPC.target];
                Vector2 vector = player.Center - NPC.Center;
                vector.Normalize();
                NPC.velocity = vector * 4;

                if (Main.netMode != 1)
                {
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, vector * 8, ProjectileID.EyeFire, 50, 2f, Main.myPlayer);
                    {

                    }

                }
            }


        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)//生成率
        {
            if (Main.hardMode) 
            {
                return SpawnCondition.Underground.Chance * 0.01f;
            }
            return 0;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(Terraria.GameContent.ItemDropRules.ItemDropRule.Common(ModContent.ItemType<watersoul>(),3,1,6));
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
