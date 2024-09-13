using Terraria;
using Terraria.ModLoader;
using WeaponDemo;
using Terraria.ID;
using Terraria.DataStructures;

namespace WeaponDemo.Items
{
    public class watersoul:ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 6));
            ItemID.Sets.AnimatesAsSoul[Type] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(silver: 1, copper: 40);
            Item.rare = ItemRarityID.Blue;
            Item.rare = 5;

        }
   
    }
}
