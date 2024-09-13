
using IL.Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WeaponDemo.Projectiles;
using WeaponDemo.Items;
using WeaponDemo.Tile;


namespace WeaponDemo.Items.Craftstatation
{
    public class Soullabitem:ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 33;
            Item.height = 31;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.rare = 12;
            Item.value = Item.sellPrice(platinum: 2, gold: 50);
            Item.createTile = ModContent.TileType<CosmicAnvil>();
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Torch,99);
            recipe.AddIngredient(ItemID.IronBar, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
