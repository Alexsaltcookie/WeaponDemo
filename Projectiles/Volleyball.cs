using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace WeaponDemo.Projectiles
{
    public class Volleyball : ModProjectile
    {
        public new string LocalizationCategory => "Projectiles.Rogue";
        public override string Texture => "WeaponDemo/Items/Vol";
        public override void SetDefaults()
        {
            Projectile.width = Projectile.height = 48;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = true;
            Projectile.alpha = 0;
            Projectile.DamageType = DamageClass.Melee;
        }
        public override void AI()
        {
            if (Projectile.ai[0]++ > 45f)
            {
                if (Projectile.velocity.Y < 7f)
                    Projectile.velocity.Y += 0.30f;
            }
            Projectile.rotation += MathHelper.ToRadians(Projectile.velocity.Length());
        }


    }
}
