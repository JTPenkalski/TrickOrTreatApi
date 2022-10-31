using Microsoft.AspNetCore.Mvc;
using TrickOrTreatApi.Models;

namespace TrickOrTreatApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrickOrTreatController : ControllerBase
    {
        private static readonly IDictionary<string, string> CANDY_IMAGES = new Dictionary<string, string>()
        {
            { "Twix", @"https://i5.walmartimages.com/asr/6acb3d09-8eee-4384-af38-e361eb0c9ad6_1.202b0ef846cba6460501ba0cddef2893.jpeg" },
            { "KitKat", @"https://target.scene7.com/is/image/Target/GUEST_319372ae-60f5-4054-9394-59a2080c789e?wid=488&hei=488&fmt=pjpeg" },
            { "Snickers", @"https://images.heb.com/is/image/HEBGrocery/000121400" },
            { "3 Musketeers", @"https://products.blains.com/600/16/164481.jpg" },
            { "MnM's", @"https://cdn.mms.com/26445-41141/cms/41141/files/aa2132f4-bcab-48fd-931e-20e19bae6d04?maxWidth=350&_mzcb=_1663721718430" },
            { "Skittles", @"https://images.chickadvisor.com/item/42093/375/i/skittles-original.jpg" },
            { "Starburst", @"https://www.candywarehouse.com/item-images/127473-01_original-starburst-fruit-chews-candy-packs-36-piece-box.jpg" },
            { "Reese's Peanut Butter Cup", @"https://www.candywarehouse.com/item-images/126443-01_reeses-peanut-butter-cups-snack-size-packs-25-piece-bag.jpg?resizeid=102&resizeh=500&resizew=500" },
            { "Twizzlers", @"https://m.media-amazon.com/images/S/aplus-media/sota/6917cd85-cc87-48e7-baa2-09cb8b10e76b.__CR0,1,970,600_PT0_SX970_V1___.png" },
            { "Crunch", @"https://images.heb.com/is/image/HEBGrocery/000098268" }
        };

        private static readonly ISet<string> TRICK_IMAGES = new HashSet<string>()
        {
            @"https://cdn.vox-cdn.com/thumbor/pr3jD5sfTRKpPinnYym_4A0gJaQ=/0x27:4415x3338/1400x1400/filters:focal(0x27:4415x3338):format(jpeg)/cdn.vox-cdn.com/uploads/chorus_image/image/43170476/ghosts.0.0.jpg",
            @"https://static.wikia.nocookie.net/deadliestfiction/images/c/ca/PVZ_Zombie_Suit.png/revision/latest/scale-to-width-down/1200?cb=20131126175343",
            @"https://media.istockphoto.com/vectors/halloween-frankenstein-vector-illustration-frankenstein-face-for-vector-id1175051596?k=20&m=1175051596&s=612x612&w=0&h=w2ILwtVNS9twFu2X7Ubs-XLlB_UtQIO7azbPuJ4cacM=",
            @"https://static.wikia.nocookie.net/vsbattles/images/e/ea/Skeletron.png/revision/latest?cb=20161111185800",
            @"https://upload.wikimedia.org/wikipedia/en/2/29/Count_von_Count_kneeling.png"
        };

        [HttpGet(Name = "GetTrickOrTreat")]
        public HalloweenItem Get()
        {
            if (Random.Shared.Next(0, 100) <= 50)
            {
                // Trick
                return new HalloweenItem(HalloweenItem.Type.Trick, null, TRICK_IMAGES.ElementAt(Random.Shared.Next(TRICK_IMAGES.Count)));
            }
            else
            {
                // Treat
                string candyName = CANDY_IMAGES.Keys.ElementAt(Random.Shared.Next(CANDY_IMAGES.Count));
                return new HalloweenItem(HalloweenItem.Type.Treat, candyName, CANDY_IMAGES[candyName], Random.Shared.Next(1, 5));
            }
        }
    }
}
