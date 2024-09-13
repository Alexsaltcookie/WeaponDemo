using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WeaponDemo.Projectiles
{
    internal class Ray : ModProjectile//弹幕
    {
        public override void SetStaticDefaults() //预设静态值
        {
            Main.projFrames[Projectile.type] = 4; //剑气帧率
        }
        public override void SetDefaults() //预设值
        {
            Projectile.DamageType = DamageClass.Ranged;//不相等的
            Projectile.width = 64;//弹幕宽度
            Projectile.height = 32;//弹幕高度
            Projectile.friendly = true;//弹幕友方
            Projectile.penetrate = -1;//穿透->无限穿透
            Projectile.tileCollide = false;//穿透墙壁
            Projectile.light = 1f;
            Projectile.CritChance = 5;

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPC(target, damage, knockback, crit);
            if (crit == true)
            {
                target.AddBuff(36, 600);
            }
        }
        public override void AI()
        {
            Projectile.velocity *= 0.99f;
            Projectile.rotation = Projectile.velocity.ToRotation();
            Projectile.frame++;
            Projectile.frame = (Projectile.frameCounter / 10) % Main.projFrames[Type];
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] > 360f)
            {
                Projectile.Kill();
            }
            base.AI();
            
        }
        
    }
}
