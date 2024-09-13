using IL.Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WeaponDemo.Projectiles;

namespace WeaponDemo.Items
{
	public class Knife : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Knife"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("在挥砍的同时留下弹幕 造成滞留伤害 弹幕会逐渐消失");
		}

		public override void SetDefaults()
		{
			Item.damage = 500;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Ray>();
			

        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddIngredient(ModContent.ItemType<watersoul>());
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
        
		
		

    }
}