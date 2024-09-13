using IL.Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Mono.Cecil;
using On.Terraria.Audio;
using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using WeaponDemo.Projectiles;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace WeaponDemo.Items
{
    public class AK : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Knife"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("露头就秒!!!");
            

        }

        public override void SetDefaults()
        {
            
            base.SetDefaults();
            Item.SetWeaponValues(2500, 1f, 68);
            Item.DefaultToRangedWeapon(12, AmmoID.Bullet, 1, 16f, true);
            Item.useAnimation = 5;
            Item.useTime = 5;
            Item.crit = 6;
            
        }
       




        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.35f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6f, 1f);

        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            
            if (player.moveSpeed == 0f)
            {
                velocity = velocity.RotatedByRandom(MathHelper.ToRadians(0)); //随机散射 后坐力
            }
            if (player.moveSpeed >= 0f) 
            {
                velocity = velocity.RotatedByRandom(MathHelper.ToRadians(34)); //随机散射 后坐力
            }


        }
    }
   
    }

