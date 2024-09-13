using IL.Terraria.ID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using WeaponDemo.Projectiles;

namespace WeaponDemo.Items
{
    public class Vol:ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.damage = 24;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.useStyle = Terraria.ID.ItemUseStyleID.Swing;
            Item.knockBack = 4f;
            Item.useAnimation = 40;
            Item.useTime = 40;
            Item.autoReuse = true;
            Item.rare = 12;
            Item.shootSpeed = 8f;
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<Volleyball>();
        }
        
    }
}
