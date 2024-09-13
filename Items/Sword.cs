using Terraria;//引用
using Terraria.ID;
using Terraria.ModLoader;
using WeaponDemo.Projectiles;
using WeaponDemo.Items;
using static MonoMod.Cil.ILContext;
using WeaponDemo.Tile;

namespace WeaponDemo.Items
{
    public class Sword:ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("露头就秒!!!");
        }
        public override void SetDefaults()
        {
            Item.damage = 160; //伤害定义  
            Item.crit = 16;//暴击率
            Item.DamageType = DamageClass.Melee;//类型近战
            Item.width = 64;
            Item.height = 64;
            Item.useTime = 50;//攻速
            Item.useAnimation = 30;
            Item.useStyle = 1;//剑类
            Item.knockBack = 6;//击退
            Item.value = 10000;
            Item.rare = 13;
            Item.autoReuse = true;
            //射弹V
            Item.shoot = ModContent.ProjectileType<C>();//引用模组内容
            Item.shootSpeed = 10f;//速度
        }
        public override void AddRecipes() //合成方式
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(3467,10);//夜明锭
            recipe.AddIngredient(22, 200);//铁锭
            recipe.AddIngredient(ModContent.ItemType<watersoul>(), 4);
            Recipe recipe1 = recipe.AddIngredient(ModContent.GetInstance<Knife>());
            recipe.AddTile(ModContent.TileType<CosmicAnvil>());//制作站恶魔祭坛
            recipe.Register();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            base.OnHitNPC(player, target, damage, knockBack, crit);
            if (crit == true)
            {
                player.AddBuff(25, 300); //暴击给予玩家醉酒效果
            }
            else
            {
                target.AddBuff(69, 300);//未造成暴击给予目标灵液效果

            }
        }
        
         
        
    }
}
